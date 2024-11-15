namespace BienComun.Core.Entities
{
    public class Category
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } = string.Empty; // Category name
        public string Description { get; set; } = string.Empty; // Category description
    }
}