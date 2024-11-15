using BienComun.Core.Entities;

namespace BienComun.Core.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int page, int pageSize);

}