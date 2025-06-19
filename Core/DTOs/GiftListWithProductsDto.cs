using System.Collections.Generic;

namespace BienComun.Core.DTOs;

public class GiftListWithProductsDto
{
    public int Id { get; set; }
    public string? ListName { get; set; }
    public int EventType { get; set; }
    public string? CustomEventType { get; set; }
    public string ListStatus { get; set; } = "draft";
    public int GuestCount { get; set; }
    public decimal MinContribution { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool UseMinContribution { get; set; }
    public bool TermsAccepted { get; set; }
    public System.DateTime? EventDate { get; set; }
    public System.DateTime? CampaignStartDate { get; set; }
    public string? CampaignStartTime { get; set; }
    public System.DateTime? CampaignEndDate { get; set; }
    public string? CampaignEndTime { get; set; }
    public double[]? Location { get; set; }
    public List<ProductDto> Products { get; set; } = new();
}
