using BienComun.Core.Entities;

namespace BienComun.Core.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int page, int pageSize);
}