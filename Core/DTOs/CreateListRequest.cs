using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Core.DTOs;

public class CreateListRequest
{
    public EventTypeDTO EventTypeDTO { get; set; }
    public string ListStatus { get; set; } = "draft";
    public int GuestCount { get; set; }
    public decimal MinContribution { get; set; }

    public List<ProductQuantityDTO> Products { get; set; } = new List<ProductQuantityDTO>();
    public ListDetailsDTO ListDetails { get; set; }
}
