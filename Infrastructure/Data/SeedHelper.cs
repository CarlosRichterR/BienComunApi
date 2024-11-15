using BienComun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Infrastructure.Data;

public static class SeedHelper
{
    private static List<T> LoadSeedData<T>(string fileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string rootPath = Path.Combine(currentDirectory, "..", "Infrastructure", "Data", "Seed", fileName);
        string seedPath = Path.GetFullPath(rootPath);

        if (File.Exists(seedPath))
        {
            try
            {
                return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(seedPath)) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading seed data from JSON: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"Seed file not found: {fileName}");
        }

        return new List<T>();
    }

    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        var usersData = LoadSeedData<User>("UsersSeed.json");
        if (usersData.Any())
        {
            modelBuilder.Entity<User>().HasData(usersData);
        }
    }

    public static void SeedProducts(ModelBuilder modelBuilder)
    {
        var categoriesData = LoadSeedData<Category>("CategoriesSeed.json");
        if (categoriesData.Any())
        {
            modelBuilder.Entity<Category>().HasData(categoriesData);
        }

        var suppliersData = LoadSeedData<Supplier>("SuppliersSeed.json");
        if (suppliersData.Any())
        {
            modelBuilder.Entity<Supplier>().HasData(suppliersData);
        }

        var productsData = LoadSeedData<Product>("ProductsSeed.json");
        if (productsData.Any())
        {
            modelBuilder.Entity<Product>().HasData(productsData);
        }
    }
}