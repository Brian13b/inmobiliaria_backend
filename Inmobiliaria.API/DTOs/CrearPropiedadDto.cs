using Inmobiliaria.Domain.Entities;

namespace Inmobiliaria.API.DTOs
{
    public class CrearPropiedadDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Moneda { get; set; } = "ARS";
        public decimal PrecioExpensas { get; set; }

        public string Direccion { get; set; } = string.Empty;

        public string Barrio { get; set; } = string.Empty;

        public string Ciudad { get; set; } = "Paraná";
        public int Ambientes { get; set; }
        public int Dormitorios { get; set; }
        public int Baños { get; set; }
        public int Cocheras { get; set; }

        public int Antiguedad { get; set; }

        public double SuperficieTotal { get; set; }
        public double SuperficieCubierta { get; set; }
        public TipoPropiedad Tipo { get; set; }
        public string EstadoOperacion { get; set; } = "Venta";
        public bool Activa { get; set; } = true;
        public bool EsDestacada { get; set; } = false;
        public bool TieneAgua { get; set; }
        public bool TieneGas { get; set; }
        public bool TieneLuz { get; set; }
        public bool TieneInternet { get; set; }
        public bool TienePavimento { get; set; }
        public bool TieneCloacas { get; set; }
    }
}