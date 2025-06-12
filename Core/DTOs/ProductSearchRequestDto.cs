using System.Collections.Generic;

namespace BienComun.Core.DTOs
{
    public class ProductSearchRequestDto
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? Search { get; set; }
        public string? Brand { get; set; }
        public int? SupplierId { get; set; }
        public string? Model { get; set; }
        public List<int>? CategoryIds { get; set; }
        public List<int>? SupplierIds { get; set; }
        public decimal[]? PriceRange { get; set; }
        public bool IsAdvancedSearch { get; set; } = false;
        // Puedes agregar más filtros si lo necesitas
    }
}
