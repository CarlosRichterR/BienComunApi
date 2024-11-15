using BienComun.Core.Entities;
using BienComun.Core.Repository;
using BIenComun.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            .Include(p => p.Category).ToListAsync();
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int page, int pageSize)
    {
        var totalCount = await _context.Products.CountAsync();
        var products = await _context.Products
            .Include(p => p.Supplier)
            .Include(p => p.Category)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (products, totalCount);
    }
}
