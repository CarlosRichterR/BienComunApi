namespace BienComun.Core.Entities
{
    public class GiftList
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OwnerId { get; set; } // Reference to the principal owner
        public virtual User Owner { get; set; } = null!; // Navigation to the principal owner
        //public int EventId { get; set; } // Reference to the associated event
        //public virtual Event Event { get; set; } = null!; // Navigation to the event
        //public virtual ICollection<CollaboratorList> Collaborators { get; set; } = new List<CollaboratorList>();
        //public virtual ICollection<GiftListProduct> Products { get; set; } = new List<ListProduct>();
    }
}