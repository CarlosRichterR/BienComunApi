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
        // Puedes agregar más filtros si lo necesitas
    }
}
