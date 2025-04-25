using System;

namespace BienComun.Core.DTOs;

public class ListDetailsDTO
{
    public string? ListName { get; set; }
    public DateTime? EventDate { get; set; }
    public DateTime? CampaignStartDate { get; set; }
    public string? CampaignStartTime { get; set; }
    public DateTime? CampaignEndDate { get; set; }
    public string? CampaignEndTime { get; set; }
    public double[]? Location { get; set; } // Representa [latitude, longitude]
    public string? Address { get; set; }
}

