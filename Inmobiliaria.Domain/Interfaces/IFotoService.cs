using Microsoft.AspNetCore.Http;

namespace Inmobiliaria.Domain.Interfaces
{
    public interface IFotoService
    {
        Task<string> SubirFotoAsync(IFormFile archivo);
        Task BorrarFotoAsync(string publicId); 
    }
}