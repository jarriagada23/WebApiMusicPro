using System.ComponentModel.DataAnnotations;


//Creacion Clase StockDTO
namespace WebApiMusicPro.Models
{
    public class StockDTO
    {
        [Key]
        public int idStock { get; set; }

        public int total_prod { get; set; }

        public string bodega { get; set; }

        public int idProductostock { get; set; }

        public string nombreProducto { get; set; }

    }
}
