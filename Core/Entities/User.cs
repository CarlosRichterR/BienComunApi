namespace BienComun.Core.Entities
{
    public class User
    {
        public int Id { get; set; } // Clave primaria
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; }
    }
}