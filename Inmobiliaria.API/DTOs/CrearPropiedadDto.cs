using Inmobiliaria.Domain.Entities;

namespace Inmobiliaria.API.DTOs
{
    public class CrearPropiedadDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Moneda { get; set; } = "ARS";
        public string Direccion { get; set; } = string.Empty;
        public int Ambientes { get; set; }
        public int Dormitorios { get; set; }
        public int Baños { get; set; }
        public int Cocheras { get; set; }
        public double SuperficieTotal { get; set; }
        public double SuperficieCubierta { get; set; }
        public TipoPropiedad Tipo { get; set; }
        public string Ciudad { get; set; } = "Paraná"; 
        public string EstadoOperacion { get; set; } = "Venta";
        public bool Activa { get; set; } = true;
        public bool EsDestacada { get; set; } = false;

    }
}