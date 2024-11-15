namespace BienComun.Core.Entities;

public class Photo
{
    public int Id { get; set; }
    public int ProductId { get; set; } // Reference to the product
    public virtual Product Product { get; set; } = null!; // Navigation to the product
    public string PhotoUrl { get; set; } = string.Empty;
    public int Order { get; set; } // Order of the photo (to define the main photo)
}