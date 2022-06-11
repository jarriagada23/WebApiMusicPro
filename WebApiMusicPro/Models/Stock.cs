using System.ComponentModel.DataAnnotations;

namespace WebApiMusicPro.Models
{
    public class Stock
    {
        [Key]
        public int idStock { get; set; }

        public int total_prod { get; set; }

        public string bodega { get; set; }

        public int idProductostock { get; set; }



    }
}
