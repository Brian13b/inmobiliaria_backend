namespace Inmobiliaria.Domain.Entities
{
    public enum TipoPropiedad { Casa, Departamento, Terreno, Local, Oficina }
    public enum EstadoInmueble { Excelente, MuyBueno, Bueno, Regular, ARefaccionar }
    public enum Orientacion { Norte, Sur, Este, Oeste, Noreste, Noroeste, Sudeste, Sudoeste }
    public enum Disposicion { Frente, Contrafrente, Lateral, Interno }

    public class Propiedad
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Moneda { get; set; } = "ARS";
        public decimal? PrecioExpensas { get; set; }

        public string Direccion { get; set; } = string.Empty;
        public string Barrio { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public int Ambientes { get; set; }
        public int Dormitorios { get; set; }
        public int Baños { get; set; }
        public int Cocheras { get; set; }
        public int Antiguedad { get; set; }

        public double SuperficieTotal { get; set; }
        public double SuperficieCubierta { get; set; }

        public TipoPropiedad Tipo { get; set; }
        public EstadoInmueble Estado { get; set; } = EstadoInmueble.Excelente;
        public Orientacion Orientacion { get; set; } = Orientacion.Norte;
        public Disposicion Disposicion { get; set; } = Disposicion.Frente;

        public bool Activa { get; set; } = true;
        public bool EsDestacada { get; set; } = false;
        public string EstadoOperacion { get; set; } = "Venta";
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public List<ImagenPropiedad> Imagenes { get; set; } = new List<ImagenPropiedad>();

        // --- SERVICIOS ---
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

        // --- COMODIDADES / AMBIENTES ---
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
