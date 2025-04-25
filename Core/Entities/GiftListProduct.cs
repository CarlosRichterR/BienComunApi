using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BienComun.Core.Entities;

public class GiftListProduct
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("GiftList")]
    public int GiftListId { get; set; }
    public virtual GiftList GiftList { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
}
