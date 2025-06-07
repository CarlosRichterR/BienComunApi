using BienComun.Core.Entities;
using BienComun.Core.DTOs;

namespace BienComun.Core.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int page, int pageSize);
    Task<(IEnumerable<Product> Products, int TotalCount)> SearchPaginatedProductsAsync(ProductSearchRequestDto request);
    Task RebuildProductIndexAsync();
}