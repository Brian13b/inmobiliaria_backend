using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Infrastructure.Repositories
{
    public class PropiedadRepository : IPropiedadRepository
    {
        private readonly ApplicationDbContext _context;

        public PropiedadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Propiedad>> GetAllAsync()
        {
            // Incluimos las imágenes al traer la propiedad
            return await _context.Propiedades
                                 .Include(p => p.Imagenes)
                                 .ToListAsync();
        }

        public async Task<Propiedad?> GetByIdAsync(int id)
        {
            return await _context.Propiedades
                                 .Include(p => p.Imagenes)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Propiedad> AddAsync(Propiedad propiedad)
        {
            await _context.Propiedades.AddAsync(propiedad);
            await _context.SaveChangesAsync();
            return propiedad;
        }

        public async Task UpdateAsync(Propiedad propiedad)
        {
            _context.Entry(propiedad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var propiedad = await _context.Propiedades.FindAsync(id);
            if (propiedad != null)
            {
                _context.Propiedades.Remove(propiedad);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddImagenAsync(ImagenPropiedad imagen)
        {
            await _context.ImagenesPropiedades.AddAsync(imagen);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImagenAsync(int imagenId)
        {
            var imagen = await _context.ImagenesPropiedades.FindAsync(imagenId);

            if (imagen != null)
            {
                _context.ImagenesPropiedades.Remove(imagen);
                await _context.SaveChangesAsync();
            }
        }
    }
}