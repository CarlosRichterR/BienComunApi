using System.ComponentModel.DataAnnotations.Schema;

namespace BienComun.Core.Entities;

public class ProductImage
{
    public int Id { get; set; }
    public int ProductId { get; set; } // Foreign key to Product
    public string ImageUrl { get; set; } = string.Empty; // URL of the image
    public bool IsThumbnail { get; set; } // Indicates if this is a thumbnail

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!; // Navigation property
}
