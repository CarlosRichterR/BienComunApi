using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BienComun.Core.Entities
{
    public class Contribution
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("GiftListProduct")]
        public int GiftListProductId { get; set; }
        public virtual GiftListProduct GiftListProduct { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string? ContributorName { get; set; } // Opcional: nombre del aportante
        public string? Message { get; set; } // Opcional: mensaje del aportante
        // Puedes agregar más campos según necesidad
    }
}
