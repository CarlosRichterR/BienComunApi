using System.Collections.Generic;

namespace BienComun.Core.Entities
{
    public class CollaboratorList
    {
        public int Id { get; set; }
        public int GiftListId { get; set; } // Reference to the list
        public virtual GiftList List { get; set; } = null!; // Navigation to the list
        public Guid UserId { get; set; } // Reference to the collaborator user
        public virtual User User { get; set; } = null!; // Navigation to the user
        public string Role { get; set; } = string.Empty; // Role of the collaborator (Editor, Viewer, etc.)
    }
}