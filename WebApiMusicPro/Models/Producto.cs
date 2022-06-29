using System.ComponentModel.DataAnnotations;

//Creacion Clase Producto
namespace WebApiMusicPro.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string categoria { get; set; }
        public string imagen { get; set; }
        public int precio { get; set; }
    }
}
