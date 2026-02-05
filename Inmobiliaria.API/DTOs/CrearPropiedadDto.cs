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

        // Nuevos Enums
        public EstadoInmueble Estado { get; set; }
        public Orientacion Orientacion { get; set; }
        public Disposicion Disposicion { get; set; }

        // Servicios
        public bool TieneAgua { get; set; }
        public bool TieneGasNatural { get; set; }
        public bool TieneGasEnvasado { get; set; }
        public bool TieneLuz { get; set; }
        public bool TieneInternet { get; set; }
        public bool TienePavimento { get; set; }
        public bool TieneCloacas { get; set; }
        public bool TieneCalefon { get; set; }
        public bool TieneAscensor { get; set; }
        public bool TieneTelefono { get; set; }
        public bool TieneSeguridad { get; set; }

        // Comodidades / Ambientes
        public bool TienePatio { get; set; }
        public bool TienePatioSeco { get; set; }
        public bool TieneBalcon { get; set; }
        public bool TieneCocina { get; set; }
        public bool TieneCocinaComedor { get; set; }
        public bool TieneLiving { get; set; }
        public bool TieneLivingComedor { get; set; }
        public bool TieneLavadero { get; set; }
        public bool TieneLavaderoSectorizado { get; set; }
    }
}