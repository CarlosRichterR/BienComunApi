using BienComun.Core.DTOs;
using BienComun.Core.Entities;
using BienComun.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BienComun.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        try
        {
            var products = await _productService.GetProductsAsync();
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Supplier = p.Supplier?.Name ?? string.Empty,
                Category = p.Category?.Name ?? string.Empty,
                ImageUrl = p.ImageUrl,
                Quantity = p.Quantity,
                ReferenceUrl = p.ReferenceUrl
            });
            return Ok(productDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpGet("paginated")]
    public async Task<ActionResult<PaginatedResponseDto<ProductDto>>> GetPaginatedProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var (products, totalCount) = await _productService.GetPaginatedProductsAsync(page, pageSize);
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Supplier = p.Supplier?.Name ?? string.Empty,
                Category = p.Category?.Name ?? string.Empty,
                ImageUrl = p.ImageUrl,
                Quantity = p.Quantity,
                ReferenceUrl = p.ReferenceUrl
            });
            var response = new PaginatedResponseDto<ProductDto>
            {
                TotalCount = totalCount,
                Items = productDtos
            };
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}