using BienComun.Core.Entities;
using BienComun.Core.Interfaces;
using BienComun.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> GetPaginatedProductsAsync(int page, int pageSize)
    {
        return await _productRepository.GetPaginatedProductsAsync(page, pageSize);
    }
}
