namespace BienComun.Core.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int? Quantity { get; set; }
    public string? ReferenceUrl { get; set; }
    public string Brand { get; set; } = string.Empty; // Brand of the product
    public string ThumbnailUrl { get; set; } = string.Empty; // URL for the thumbnail image
    public List<string> ImageUrls { get; set; } = new List<string>(); // URLs for high-quality images
}
