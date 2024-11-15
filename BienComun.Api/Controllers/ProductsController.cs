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
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        try
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpGet("paginated")]
    public async Task<ActionResult<PaginatedResponseDto<Product>>> GetPaginatedProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var (products, totalCount) = await _productService.GetPaginatedProductsAsync(page, pageSize);
            var response = new PaginatedResponseDto<Product>
            {
                TotalCount = totalCount,
                Items = products
            };
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}