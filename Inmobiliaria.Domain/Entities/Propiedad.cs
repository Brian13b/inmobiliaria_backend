namespace Inmobiliaria.Domain.Entities
{
    public enum TipoPropiedad
    {
        Casa,
        Departamento,
        Terreno,
        Local,
        Oficina
    }

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
        public int Antiguedad { get; set; } // 0 = A estrenar

        public double SuperficieTotal { get; set; } // m2 terreno total
        public double SuperficieCubierta { get; set; } // m2 construidos

        public TipoPropiedad Tipo { get; set; }

        public bool Activa { get; set; } = true;
        public bool EsDestacada { get; set; } = false;
        public string EstadoOperacion { get; set; } = "Venta"; // Venta/Alquiler
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public List<ImagenPropiedad> Imagenes { get; set; } = new List<ImagenPropiedad>();
    }
}
