using BienComun.Core.DTOs;
using BienComun.Core.Entities;

namespace BienComun.Core.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int page, int pageSize);
    Task<(IEnumerable<Product> Products, int TotalCount)> SearchPaginatedProductsAsync(ProductSearchRequestDto request);
    Task RebuildProductIndexAsync();
}