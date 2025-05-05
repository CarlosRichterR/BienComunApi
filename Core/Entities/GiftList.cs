using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BienComun.Core.Enums;

namespace BienComun.Core.Entities
{
    public class GiftList
    {
        [Key]
        public int Id { get; set; }
        public EventType EventType { get; set; }
        public string? CustomEventType { get; set; }
        public string ListStatus { get; set; } = "draft";
        public int GuestCount { get; set; }
        public decimal MinContribution { get; set; }
        public string? ListName { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public string? CampaignStartTime { get; set; }
        public DateTime? CampaignEndDate { get; set; }
        public string? CampaignEndTime { get; set; }
        public double[]? Location { get; set; } // Representa [latitude, longitude]
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool UseMinContribution { get; set; }
        public bool TermsAccepted { get; set; }

        // Nueva colección para los productos
        public virtual ICollection<GiftListProduct> Products { get; set; } = new List<GiftListProduct>();
    }
}