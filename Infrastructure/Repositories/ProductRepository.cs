using BienComun.Core.Entities;
using BienComun.Core.Repository;
using BienComun.Core.DTOs;
using BIenComun.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace BienComun.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Supplier)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .ToListAsync();
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int page, int pageSize)
    {
        var totalCount = await _context.Products.CountAsync();
        var products = await _context.Products
            .Include(p => p.Supplier)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (products, totalCount);
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> SearchPaginatedProductsAsync(ProductSearchRequestDto request)
    {
        // Si la búsqueda avanzada está activada, redirigir a la función avanzada
        if (request.IsAdvancedSearch)
        {
            return await SearchPaginatedProductsAdvancedAsync(request);
        }
        var luceneVersion = LuceneVersion.LUCENE_48;
        var indexPath = "lucene_index";
        if (!System.IO.Directory.Exists(indexPath))
        {
            System.IO.Directory.CreateDirectory(indexPath);
        }
        var dir = FSDirectory.Open(indexPath);
        var analyzer = new StandardAnalyzer(luceneVersion);

        // Si el índice está vacío, retorna vacío
        if (dir.ListAll().Length == 0)
        {
            return (new List<Product>(), 0);
        }

        IndexSearcher searcher;
        try
        {
            searcher = new IndexSearcher(DirectoryReader.Open(dir));
        }
        catch (Lucene.Net.Index.IndexNotFoundException)
        {
            return (new List<Product>(), 0);
        }

        // Build Lucene query (fuzzy + wildcard search for similar terms and prefixes, case-insensitive)
        var query = new BooleanQuery();
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var searchTerm = request.Search.ToLowerInvariant();
            var parser = new MultiFieldQueryParser(luceneVersion, new[] { "Name", "Description", "Brand", "CategoryName", "SupplierName" }, analyzer);
            // Aplica fuzzy (~) y wildcard (*) a cada palabra
            var fuzzyTerms = string.Join(" ", searchTerm.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(t => QueryParserBase.Escape(t) + "~"));
            var wildcardTerms = string.Join(" ", searchTerm.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(t => QueryParserBase.Escape(t) + "*"));
            var combinedQuery = $"({fuzzyTerms}) ({wildcardTerms})";
            var searchQuery = parser.Parse(combinedQuery);
            query.Add(searchQuery, Occur.MUST);
        }
        if (!string.IsNullOrWhiteSpace(request.Brand))
        {
            var brandQuery = new TermQuery(new Term("Brand", request.Brand.ToLowerInvariant()));
            query.Add(brandQuery, Occur.MUST);
        }
        if (request.SupplierId.HasValue)
        {
            var supplierQuery = NumericRangeQuery.NewInt32Range("SupplierId", request.SupplierId.Value, request.SupplierId.Value, true, true);
            query.Add(supplierQuery, Occur.MUST);
        }
        // Búsqueda por nombre de proveedor (fuzzy)
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            // Si el término de búsqueda coincide con algún proveedor
            var matchingSuppliers = await _context.Suppliers
                .Where(s => s.Name.ToLower().Contains(request.Search.ToLower()))
                .Select(s => s.Id)
                .ToListAsync();
            if (matchingSuppliers.Any())
            {
                var supplierNameQuery = new BooleanQuery();
                foreach (var id in matchingSuppliers)
                {
                    supplierNameQuery.Add(NumericRangeQuery.NewInt32Range("SupplierId", id, id, true, true), Occur.SHOULD);
                }
                query.Add(supplierNameQuery, Occur.SHOULD);
            }
        }

        // Search Lucene index
        int maxResults = 1000; // Limit for non-paginated
        TopDocs topDocs = searcher.Search(query, (request.Page.HasValue && request.PageSize.HasValue) ? request.Page.Value * request.PageSize.Value : maxResults);
        var totalCount = topDocs.TotalHits;

        // Pagination logic
        int skip = (request.Page.HasValue && request.PageSize.HasValue) ? (request.Page.Value - 1) * request.PageSize.Value : 0;
        int take = (request.Page.HasValue && request.PageSize.HasValue) ? request.PageSize.Value : maxResults;
        var docs = topDocs.ScoreDocs.Skip(skip).Take(take);

        // Map Lucene docs to Product entities (implement a method to fetch from DB by IDs)
        var productIds = docs.Select(d => int.Parse(searcher.Doc(d.Doc).Get("Id"))).ToList();
        var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Include(p => p.Supplier)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .ToListAsync();
        // Order by Lucene relevance
        products = productIds.Select(id => products.First(p => p.Id == id)).ToList();

        return (products, (int)totalCount);
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> SearchPaginatedProductsAdvancedAsync(ProductSearchRequestDto request)
    {
        var query = _context.Products
            .Include(p => p.Supplier)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .AsQueryable();

        // Aplica primero los filtros avanzados
        if (request.CategoryIds != null && request.CategoryIds.Any())
        {
            query = query.Where(p => request.CategoryIds.Contains(p.CategoryId));
        }
        if (request.SupplierIds != null && request.SupplierIds.Any())
        {
            query = query.Where(p => request.SupplierIds.Contains(p.SupplierId));
        }
        if (request.PriceRange != null && request.PriceRange.Length == 2)
        {
            decimal min = request.PriceRange[0];
            decimal max = request.PriceRange[1];
            query = query.Where(p => p.Price >= min && p.Price <= max);
        }
        if (!string.IsNullOrWhiteSpace(request.Brand))
        {
            query = query.Where(p => p.Brand.ToLower() == request.Brand.ToLower());
        }
        if (request.SupplierId.HasValue)
        {
            query = query.Where(p => p.SupplierId == request.SupplierId.Value);
        }

        // Solo aplica el filtro de búsqueda si hay término de búsqueda
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var searchTerm = request.Search.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(searchTerm) ||
                p.Description.ToLower().Contains(searchTerm) ||
                p.Brand.ToLower().Contains(searchTerm) ||
                p.Category.Name.ToLower().Contains(searchTerm) ||
                p.Supplier.Name.ToLower().Contains(searchTerm)
            );
        }

        var totalCount = await query.CountAsync();
        int skip = (request.Page.HasValue && request.PageSize.HasValue) ? (request.Page.Value - 1) * request.PageSize.Value : 0;
        int take = (request.Page.HasValue && request.PageSize.HasValue) ? request.PageSize.Value : 1000;
        var products = await query.Skip(skip).Take(take).ToListAsync();
        return (products, totalCount);
    }

    // Método para reindexar todos los productos en Lucene
    public async Task RebuildProductIndexAsync()
    {
        var luceneVersion = LuceneVersion.LUCENE_48;
        var indexPath = "lucene_index";
        if (!System.IO.Directory.Exists(indexPath))
        {
            System.IO.Directory.CreateDirectory(indexPath);
        }
        var dir = FSDirectory.Open(indexPath);
        var analyzer = new StandardAnalyzer(luceneVersion);
        var config = new IndexWriterConfig(luceneVersion, analyzer);
        using var writer = new IndexWriter(dir, config);

        // Limpiar el índice existente
        writer.DeleteAll();

        // Incluir la categoría y el nombre del proveedor al obtener los productos
        var products = await _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToListAsync();
        foreach (var product in products)
        {
            var doc = new Lucene.Net.Documents.Document
            {
                new Lucene.Net.Documents.StringField("Id", product.Id.ToString(), Lucene.Net.Documents.Field.Store.YES),
                new Lucene.Net.Documents.TextField("Name", product.Name?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.TextField("Description", product.Description?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.TextField("Brand", product.Brand?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.Int32Field("SupplierId", product.SupplierId, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.TextField("CategoryName", product.Category?.Name?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.TextField("SupplierName", product.Supplier?.Name?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO)
            };
            writer.AddDocument(doc);
        }
        writer.Commit();
    }
}
