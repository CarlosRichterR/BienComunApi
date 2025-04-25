using BienComun.Core.Entities;
using BienComun.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GiftList> GiftLists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (DesignTimeHelpers.IsDesignTime())
            {
                return; // No ejecutar el seed en tiempo de diseño (al crear migraciones)
            }

          SeedHelper.SeedUsers(modelBuilder);
          SeedHelper.SeedProducts(modelBuilder);

        }
    }

    public static class DesignTimeHelpers
    {
        public static bool IsDesignTime()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Any(x => x.FullName?.StartsWith("EntityFrameworkCore.Design") ?? false);
        }
    }
}
