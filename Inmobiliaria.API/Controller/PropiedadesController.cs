using Inmobiliaria.API.DTOs;
using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;


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

        [HttpGet("{idOrSlug}")]
        public async Task<IActionResult> GetByIdOrSlug(string idOrSlug)
        {
            Propiedad? propiedad = null;

            if (int.TryParse(idOrSlug, out int id))
            {
                propiedad = await _repository.GetByIdAsync(id);
            }
            else
            {
                propiedad = await _repository.GetBySlugAsync(idOrSlug);
            }

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
                PrecioExpensas = dto.PrecioExpensas,
                PagaExpensas = dto.PagaExpensas,
                PagaTasas = dto.PagaTasas,
                Direccion = dto.Direccion,
                Barrio = dto.Barrio,
                Ciudad = dto.Ciudad,
                Ambientes = dto.Ambientes,
                Dormitorios = dto.Dormitorios,
                Baños = dto.Baños,
                Cocheras = dto.Cocheras,
                SuperficieTotal = dto.SuperficieTotal,
                SuperficieCubierta = dto.SuperficieCubierta,
                Antiguedad = dto.Antiguedad,
                Tipo = dto.Tipo,
                Estado = dto.Estado,
                Orientacion = dto.Orientacion,
                Disposicion = dto.Disposicion,
                FechaCreacion = DateTime.UtcNow,
                Activa = dto.Activa,
                EsDestacada = dto.EsDestacada,
                EstadoOperacion = dto.EstadoOperacion,

                // Servicios
                TieneAgua = dto.TieneAgua,
                TieneGasNatural = dto.TieneGasNatural,
                TieneGasEnvasado = dto.TieneGasEnvasado,
                TieneLuz = dto.TieneLuz,
                TieneInternet = dto.TieneInternet,
                TieneCloacas = dto.TieneCloacas,
                TienePavimento = dto.TienePavimento,
                TieneCalefon = dto.TieneCalefon,
                TieneAscensor = dto.TieneAscensor,
                TieneTelefono = dto.TieneTelefono,
                TieneSeguridad = dto.TieneSeguridad,
                TieneImpMunicipales = dto.TieneImpMunicipales,
                TieneImpProvinciales = dto.TieneImpProvinciales,

                // Comodidades
                TienePatio = dto.TienePatio,
                TienePatioSeco = dto.TienePatioSeco,
                TieneBalcon = dto.TieneBalcon,
                TieneCocina = dto.TieneCocina,
                TieneCocinaComedor = dto.TieneCocinaComedor,
                TieneLiving = dto.TieneLiving,
                TieneLivingComedor = dto.TieneLivingComedor,
                TieneLavadero = dto.TieneLavadero,
                TieneLavaderoSectorizado = dto.TieneLavaderoSectorizado,
                TieneTerraza = dto.TieneTerraza,
                TieneComedor = dto.TieneComedor,
                TieneFondo = dto.TieneFondo,
                TienePiscina = dto.TienePiscina,
                TieneToilette = dto.TieneToilette,
                TieneQuincho = dto.TieneQuincho,
            };

            await _repository.AddAsync(nuevaPropiedad);

            nuevaPropiedad.Slug = SlugHelper.GenerateSlug(nuevaPropiedad.Titulo, nuevaPropiedad.Id);
            await _repository.UpdateAsync(nuevaPropiedad);

            return Ok(new { mensaje = "Propiedad creada con éxito", id = nuevaPropiedad.Id, slug = nuevaPropiedad.Slug });
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

            int siguienteOrden = propiedad.Imagenes.Any() ? propiedad.Imagenes.Max(i => i.Orden) + 1 : 0;

            var nuevaImagen = new ImagenPropiedad
            {
                PropiedadId = id,
                Url = urlImagen,
                Orden = siguienteOrden
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

            // Datos Básicos
            propiedad.Titulo = dto.Titulo;
            propiedad.Descripcion = dto.Descripcion;
            propiedad.Precio = dto.Precio;
            propiedad.Moneda = dto.Moneda;
            propiedad.PrecioExpensas = dto.PrecioExpensas;
            propiedad.PagaExpensas = dto.PagaExpensas;
            propiedad.PagaTasas = dto.PagaTasas;
            propiedad.Direccion = dto.Direccion;
            propiedad.Barrio = dto.Barrio;
            propiedad.Ciudad = dto.Ciudad;
            propiedad.Ambientes = dto.Ambientes;
            propiedad.Dormitorios = dto.Dormitorios;
            propiedad.Baños = dto.Baños;
            propiedad.Cocheras = dto.Cocheras;
            propiedad.Antiguedad = dto.Antiguedad;
            propiedad.SuperficieTotal = dto.SuperficieTotal;
            propiedad.SuperficieCubierta = dto.SuperficieCubierta;
            propiedad.Tipo = dto.Tipo;
            propiedad.Estado = dto.Estado;
            propiedad.Orientacion = dto.Orientacion;
            propiedad.Disposicion = dto.Disposicion;
            propiedad.EstadoOperacion = dto.EstadoOperacion;
            propiedad.Activa = dto.Activa;
            propiedad.EsDestacada = dto.EsDestacada;
            propiedad.Slug = SlugHelper.GenerateSlug(propiedad.Titulo, propiedad.Id);   

            // Servicios
            propiedad.TieneAgua = dto.TieneAgua;
            propiedad.TieneGasNatural = dto.TieneGasNatural;
            propiedad.TieneGasEnvasado = dto.TieneGasEnvasado;
            propiedad.TieneLuz = dto.TieneLuz;
            propiedad.TieneInternet = dto.TieneInternet;
            propiedad.TieneCloacas = dto.TieneCloacas;
            propiedad.TienePavimento = dto.TienePavimento;
            propiedad.TieneCalefon = dto.TieneCalefon;
            propiedad.TieneAscensor = dto.TieneAscensor;
            propiedad.TieneTelefono = dto.TieneTelefono;
            propiedad.TieneSeguridad = dto.TieneSeguridad;
            propiedad.TieneImpMunicipales = dto.TieneImpMunicipales;
            propiedad.TieneImpProvinciales = dto.TieneImpProvinciales;

            // Comodidades
            propiedad.TienePatio = dto.TienePatio;
            propiedad.TienePatioSeco = dto.TienePatioSeco;
            propiedad.TieneBalcon = dto.TieneBalcon;
            propiedad.TieneCocina = dto.TieneCocina;
            propiedad.TieneCocinaComedor = dto.TieneCocinaComedor;
            propiedad.TieneLiving = dto.TieneLiving;
            propiedad.TieneLivingComedor = dto.TieneLivingComedor;
            propiedad.TieneLavadero = dto.TieneLavadero;
            propiedad.TieneLavaderoSectorizado = dto.TieneLavaderoSectorizado;
            propiedad.TieneTerraza = dto.TieneTerraza;
            propiedad.TieneComedor = dto.TieneComedor;
            propiedad.TieneFondo = dto.TieneFondo;
            propiedad.TienePiscina = dto.TienePiscina;
            propiedad.TieneToilette = dto.TieneToilette;
            propiedad.TieneQuincho = dto.TieneQuincho;

            await _repository.UpdateAsync(propiedad);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var propiedad = await _repository.GetByIdAsync(id);
            if (propiedad == null) return NotFound();

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

        [HttpPut("{id}/imagenes/orden")]
        [Authorize]
        public async Task<IActionResult> ReordenarImagenes(int id, [FromBody] List<int> imagenIds)
        {
            var propiedad = await _repository.GetByIdAsync(id);
            if (propiedad == null) return NotFound();

            foreach (var img in propiedad.Imagenes)
            {
                int nuevoOrden = imagenIds.IndexOf(img.Id);
                if (nuevoOrden != -1)
                {
                    img.Orden = nuevoOrden;
                }
            }

            await _repository.UpdateAsync(propiedad);
            return NoContent();
        }
    }
}