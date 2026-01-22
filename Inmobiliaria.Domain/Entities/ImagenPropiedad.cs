namespace Inmobiliaria.Domain.Entities
{
    public class ImagenPropiedad
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty; 

        public int Orden { get; set; }

        public int PropiedadId { get; set; }
        public Propiedad Propiedad { get; set; } = null!;
    }
}