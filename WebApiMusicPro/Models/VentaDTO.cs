﻿using System.ComponentModel.DataAnnotations;

namespace WebApiMusicPro.Models
{
    public class VentaDTO
    {

        [Key]
        public int idDetalleVenta { get; set; }

        public int idVenta { get; set; }

        public int idProducto { get; set; }

        public int cantidad { get; set; }

        public int total { get; set; }

        public DateTime fecha { get; set; }

        public string nombreProducto { get; set; }
    }
}
