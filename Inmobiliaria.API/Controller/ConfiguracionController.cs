using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Domain.Interfaces;

namespace Inmobiliaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFotoService _fotoService;

        public ConfiguracionController(ApplicationDbContext context, IFotoService fotoService)
        {
            _context = context;
            _fotoService = fotoService;
        }

        [HttpPost("UploadImage")]
        [Authorize]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            if (image == null) return BadRequest("No se recibió ninguna imagen");

            var url = await _fotoService.SubirFotoAsync(image, true);

            if (string.IsNullOrEmpty(url)) return BadRequest("Error al subir a Cloudinary");

            return Ok(new { url });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var config = await _context.Configuraciones.FirstOrDefaultAsync();
            if (config == null)
            {
                return Ok(new Configuracion());
            }
            return Ok(config);
        }

        [HttpPost] 
        [Authorize]
        public async Task<IActionResult> Update([FromBody] Configuracion dto)
        {
            var config = await _context.Configuraciones.FirstOrDefaultAsync();
            if (config == null)
            {
                config = new Configuracion();
                _context.Configuraciones.Add(config);
            }

            config.HeroTitulo = dto.HeroTitulo;
            config.HeroSubtitulo = dto.HeroSubtitulo;
            config.HeroImagenUrl = dto.HeroImagenUrl;

            config.HeroTitulo2 = dto.HeroTitulo2;
            config.HeroSubtitulo2 = dto.HeroSubtitulo2;
            config.HeroImagenUrl2 = dto.HeroImagenUrl2;

            await _context.SaveChangesAsync();
            return Ok(config);
        }
    }
}
