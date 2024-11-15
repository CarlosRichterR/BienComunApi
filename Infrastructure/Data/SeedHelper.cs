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
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        // Construir la ruta absoluta para encontrar el archivo JSON de seed
        string currentDirectory = Directory.GetCurrentDirectory();
        string userRootPath = Path.Combine(currentDirectory, "..", "Infrastructure", "Data", "Seed", "UsersSeed.json");

        // Normalizar la ruta para evitar problemas de compatibilidad con distintos sistemas operativos
        string usersSeedPath = Path.GetFullPath(userRootPath);

        if (File.Exists(usersSeedPath))
        {
            try
            {
                var usersData = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(usersSeedPath));
                if (usersData != null && usersData.Any())
                {
                    modelBuilder.Entity<User>().HasData(usersData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading seed data from JSON: {ex.Message}");
            }
        }
    }
}

