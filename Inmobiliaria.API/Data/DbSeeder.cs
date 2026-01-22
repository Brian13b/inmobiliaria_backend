using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Infrastructure.Data;
using BCrypt.Net;

namespace Inmobiliaria.API.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Usuarios.Any()) return;

            var admin = new Usuario
            {
                NombreUsuario = "admin",
                Email = "admin@inmobiliaria.com",
                Rol = "Admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!")
            };

            await context.Usuarios.AddAsync(admin);
            await context.SaveChangesAsync();
        }
    }
}