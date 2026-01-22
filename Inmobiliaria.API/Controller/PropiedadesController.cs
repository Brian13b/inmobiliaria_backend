using Inmobiliaria.API.DTOs;
using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadesController : ControllerBase
    {
        private readonly IPropiedadRepository _repository;

        public PropiedadesController(IPropiedadRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var propiedades = await _repository.GetAllAsync();
            return Ok(propiedades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var propiedad = await _repository.GetByIdAsync(id);

            if (propiedad == null) return NotFound("Propiedad no encontrada");

            return Ok(propiedad);
        }

        [HttpGet("activas")]
        public async Task<ActionResult<IEnumerable<Propiedad>>> GetPropiedadesActivas()
        {
            var activas = await _repository.GetActivasAsync();

            return Ok(activas);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Crear([FromBody] CrearPropiedadDto dto)
        {
            var nuevaPropiedad = new Propiedad
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Moneda = dto.Moneda,
                Direccion = dto.Direccion,
                Ambientes = dto.Ambientes,
                Dormitorios = dto.Dormitorios,
                Baños = dto.Baños,
                Cocheras = dto.Cocheras,
                SuperficieTotal = dto.SuperficieTotal,
                SuperficieCubierta = dto.SuperficieCubierta,
                Tipo = dto.Tipo,
                FechaCreacion = DateTime.UtcNow,
                Activa = true,
                EstadoOperacion = "Venta"
            };

            await _repository.AddAsync(nuevaPropiedad);

            return Ok(new { mensaje = "Propiedad creada con éxito", id = nuevaPropiedad.Id });
        }

        [HttpPost("{id}/imagenes")]
        [Authorize]
        public async Task<IActionResult> SubirImagen(int id, IFormFile archivo, [FromServices] IFotoService fotoService)
        {
            var propiedad = await _repository.GetByIdAsync(id);
            if (propiedad == null) return NotFound("Propiedad no encontrada");

            var urlImagen = await fotoService.SubirFotoAsync(archivo);

            if (string.IsNullOrEmpty(urlImagen))
                return BadRequest("Error al subir la imagen");

            var nuevaImagen = new ImagenPropiedad
            {
                PropiedadId = id,
                Url = urlImagen,
                Orden = 0
            };

            await _repository.AddImagenAsync(nuevaImagen);

            return Ok(new { url = urlImagen });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] CrearPropiedadDto dto)
        {
            var propiedad = await _repository.GetByIdAsync(id);
            if (propiedad == null) return NotFound("Propiedad no encontrada");

            propiedad.Titulo = dto.Titulo;
            propiedad.Descripcion = dto.Descripcion;
            propiedad.Precio = dto.Precio;
            propiedad.Moneda = dto.Moneda;
            propiedad.Ambientes = dto.Ambientes;
            propiedad.Dormitorios = dto.Dormitorios;
            propiedad.Baños = dto.Baños;
            propiedad.Cocheras = dto.Cocheras;
            propiedad.SuperficieTotal = dto.SuperficieTotal;
            propiedad.Direccion = dto.Direccion;
            propiedad.Ciudad = dto.Ciudad;
            propiedad.Tipo = dto.Tipo;
            propiedad.EstadoOperacion = dto.EstadoOperacion;
            propiedad.Activa = dto.Activa;
            propiedad.EsDestacada = dto.EsDestacada;

            await _repository.UpdateAsync(propiedad); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var propiedad = await _repository.GetByIdAsync(id);
            if (propiedad == null) return NotFound();

            // Acá deberías borrar también las fotos de Cloudinary si querés ser prolijo
            // Por ahora borramos de la BD
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}/imagenes/{imagenId}")]
        [Authorize]
        public async Task<IActionResult> DeleteImagen(int id, int imagenId)
        {
            await _repository.DeleteImagenAsync(imagenId);
            return NoContent();
        }
    }
}