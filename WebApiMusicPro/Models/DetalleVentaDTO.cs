using System.ComponentModel.DataAnnotations;

namespace WebApiMusicPro.Models
{
    public class DetalleVentaDTO
    {
        [Key]
        public int idDetalleVenta { get; set; }

        public int idVenta { get; set; }

        public int idProducto { get; set; }

        public int cantidad { get; set; }

        public int idUsuario { get; set; }

        public int total { get; set; }

        public DateTime fecha { get; set; }

    }
}
