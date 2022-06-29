using System.ComponentModel.DataAnnotations;

//Creacion Clase Detalle Venta
namespace WebApiMusicPro.Models
{
    public class DetalleVenta
    {
        [Key]
        public int idDetalleVenta { get; set; }
        
        public int idVenta { get; set; }

        public int idProducto { get; set; }

        public int cantidad { get; set; }

        

    }
}
