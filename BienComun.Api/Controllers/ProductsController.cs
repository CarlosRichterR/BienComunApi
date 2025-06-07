using BienComun.Core.DTOs;
using BienComun.Core.Entities;
using BienComun.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BienComun.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        try
        {
            var products = await _productService.GetProductsAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
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
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
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

    [HttpPost("search")]
    public async Task<ActionResult<PaginatedResponseDto<ProductDto>>> SearchPaginatedProducts([FromBody] ProductSearchRequestDto request)
    {
        try
        {
            var result = await ((IProductService)_productService).SearchPaginatedProductsAsync(request);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(result.Products);
            var response = new PaginatedResponseDto<ProductDto>
            {
                TotalCount = result.TotalCount,
                Items = productDtos
            };
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("rebuild-index")]
    public async Task<IActionResult> RebuildProductIndex()
    {
        try
        {
            await _productService.RebuildProductIndexAsync();
            return Ok(new { message = "Product Lucene index rebuilt successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error rebuilding Lucene index: {ex.Message}");
        }
    }
}