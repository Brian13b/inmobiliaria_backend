using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Domain.Entities
{
    public class Mensaje
    {
        public int Id { get; set; }
        [Required] public string Nombre { get; set; } = string.Empty;
        [Required] public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        [Required] public string Contenido { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;
        public bool Leido { get; set; } = false;

        public int? PropiedadId { get; set; }
    }
}
