using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BienComun.Core.Enums;

namespace BienComun.Core.Entities
{
    public class GiftList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public EventType EventType { get; set; }

        [MaxLength(50)]
        public string? CustomEventType { get; set; }

        [Required]
        [MaxLength(50)]
        public string ListStatus { get; set; } = "draft";

        public int GuestCount { get; set; }
        public decimal MinContribution { get; set; }

        //public string Name { get; set; } = string.Empty;
        //public int OwnerId { get; set; } // Reference to the principal owner
        //public virtual User Owner { get; set; } = null!; // Navigation to the principal owner
        //public virtual ICollection<CollaboratorList> Collaborators { get; set; } = new List<CollaboratorList>();
        //public virtual ICollection<GiftListProduct> Products { get; set; } = new List<ListProduct>();
    }
}