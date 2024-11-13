namespace BIenComun.Infrastructure.Data
{
    public class Usuario
    {
        public int Id { get; set; } // Clave primaria
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}