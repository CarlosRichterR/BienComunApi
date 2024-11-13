using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIenComun.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        // Agrega tus DbSets para cada modelo
        public DbSet<Usuario> Usuarios { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id"); // Cambia "UsuarioId" al nombre real en la base de datos
                entity.Property(e => e.Username).HasColumnName("username"); // Ejemplo si la columna se llama "NombreUsuario"
                entity.Property(e => e.Password).HasColumnName("password"); // Ejemplo si la columna se llama "Contrasena"
                entity.Property(e => e.Email).HasColumnName("email"); // Ejemplo si la columna se llama "CorreoElectronico"
                entity.Property(e => e.CreatedDate).HasColumnName("createddate"); // Ejemplo si la columna se llama "FechaCreacion"
            });

            // Llama a la implementación base
            base.OnModelCreating(modelBuilder);
        }

    }
}
