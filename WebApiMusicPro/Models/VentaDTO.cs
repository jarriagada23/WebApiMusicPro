using System.ComponentModel.DataAnnotations;

//Creacion Clase VentaDTO
namespace WebApiMusicPro.Models
{
    public class VentaDTO
    {
        [Key]
        public int idVenta { get; set; }

        public int idUsuario { get; set; }

        public int total { get; set; }

        public DateTime fecha { get; set; }

        public string nombreUsuario { get; set; }

        List<DetalleVentaDTO> detalleVentas { get; set; }
    }
}
