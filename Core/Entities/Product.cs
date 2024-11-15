using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
