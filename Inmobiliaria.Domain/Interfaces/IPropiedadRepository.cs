using Inmobiliaria.Domain.Entities;

namespace Inmobiliaria.Domain.Interfaces
{
    public interface IPropiedadRepository
    {
        Task<List<Propiedad>> GetAllAsync();
        Task<Propiedad?> GetByIdAsync(int id);

        Task<Propiedad> AddAsync(Propiedad propiedad);
        Task UpdateAsync(Propiedad propiedad);
        Task DeleteAsync(int id);

        Task AddImagenAsync(ImagenPropiedad imagen);
        Task DeleteImagenAsync(int imagenId);
    }
}