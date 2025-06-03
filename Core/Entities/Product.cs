using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienComun.Core.Entities; // Ensure the namespace for ProductImage is included

namespace BienComun.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int SupplierId { get; set; } // Reference to the supplier
        public virtual Supplier Supplier { get; set; } = null!; // Navigation to the supplier
        public int CategoryId { get; set; } // Reference to the category
        public virtual Category Category { get; set; } = null!; // Navigation to the category
        public int? Quantity { get; set; } // Optional stock quantity
        public string? ReferenceUrl { get; set; } // Optional reference link
        public string Brand { get; set; } = string.Empty; // Brand of the product
        public string ThumbnailUrl { get; set; } = string.Empty; // URL for the thumbnail image
        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>(); // High-quality images
    }
}
