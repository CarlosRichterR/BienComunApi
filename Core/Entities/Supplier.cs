namespace BienComun.Core.Entities
{
    public class Supplier
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } = string.Empty; // Supplier name
        public string Phone { get; set; } = string.Empty; // Supplier phone
        public string Email { get; set; } = string.Empty; // Supplier email
        public string Address { get; set; } = string.Empty; // Supplier address
    }
}