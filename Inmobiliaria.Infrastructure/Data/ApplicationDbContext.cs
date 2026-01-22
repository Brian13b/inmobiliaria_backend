using Inmobiliaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<ImagenPropiedad> ImagenesPropiedades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propiedad>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Propiedad>()
                .Property(p => p.PrecioExpensas)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}