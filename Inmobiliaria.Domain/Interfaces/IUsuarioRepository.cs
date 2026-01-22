using Inmobiliaria.Domain.Entities;

namespace Inmobiliaria.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByUsernameAsync(string username);
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> AddAsync(Usuario usuario);
    }
}