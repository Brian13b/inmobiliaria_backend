using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Inmobiliaria.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Infrastructure.Services
{
    public class CloudinaryService : IFotoService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration config)
        {
            var account = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> SubirFotoAsync(IFormFile archivo)
        {
            if (archivo.Length == 0) return null;

            using var stream = archivo.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(archivo.FileName, stream),
                
                Transformation = new Transformation().Height(500).Width(800).Crop("fill").Gravity("auto"),
                Folder = "inmobiliaria_casas"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }

        public async Task BorrarFotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}
