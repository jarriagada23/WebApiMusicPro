using System.ComponentModel.DataAnnotations;

namespace WebApiMusicPro.Models
{
    public class Venta
    {   
        [Key]
        public int idVenta { get; set; }

        public int idUsuario { get; set; }

        public int total { get; set; }

        public DateTime fecha { get; set; }

    }
}
