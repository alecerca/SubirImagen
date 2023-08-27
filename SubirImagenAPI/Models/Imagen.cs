using System.ComponentModel.DataAnnotations;

namespace SubirImagenAPI.Models
{
    public class Imagen
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Contenido { get; set; }
    }
}
