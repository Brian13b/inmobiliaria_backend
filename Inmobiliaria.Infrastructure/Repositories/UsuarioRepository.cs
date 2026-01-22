using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios
                                 .FirstOrDefaultAsync(u => u.NombreUsuario == username || u.Email == username);
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}