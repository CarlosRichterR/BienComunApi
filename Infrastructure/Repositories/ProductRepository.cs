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
            var parser = new MultiFieldQueryParser(luceneVersion, new[] { "Name", "Description", "Brand", "CategoryName" }, analyzer);
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

        // Incluir la categoría al obtener los productos
        var products = await _context.Products.Include(p => p.Category).ToListAsync();
        foreach (var product in products)
        {
            var doc = new Lucene.Net.Documents.Document
            {
                new Lucene.Net.Documents.StringField("Id", product.Id.ToString(), Lucene.Net.Documents.Field.Store.YES),
                new Lucene.Net.Documents.TextField("Name", product.Name?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.TextField("Description", product.Description?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.TextField("Brand", product.Brand?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.Int32Field("SupplierId", product.SupplierId, Lucene.Net.Documents.Field.Store.NO),
                new Lucene.Net.Documents.TextField("CategoryName", product.Category?.Name?.ToLowerInvariant() ?? string.Empty, Lucene.Net.Documents.Field.Store.NO)
            };
            writer.AddDocument(doc);
        }
        writer.Commit();
    }
}
