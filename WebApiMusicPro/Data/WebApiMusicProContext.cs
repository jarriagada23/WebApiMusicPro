using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiMusicPro.Models;

namespace WebApiMusicPro.Data
{
    public class WebApiMusicProContext : DbContext
    {
        public WebApiMusicProContext (DbContextOptions<WebApiMusicProContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiMusicPro.Models.Usuario>? Usuario { get; set; }

        public DbSet<WebApiMusicPro.Models.Producto>? Producto { get; set; }

        public DbSet<WebApiMusicPro.Models.Stock>? Stock { get; set; }

        public DbSet<WebApiMusicPro.Models.Venta>? Venta { get; set; }

        public DbSet<WebApiMusicPro.Models.DetalleVenta>? DetalleVenta { get; set; }

        public DbSet<WebApiMusicPro.Models.StockDTO>? StockDTO { get; set; }

        public DbSet<WebApiMusicPro.Models.VentaDTO>? VentaDTO { get; set; }

        

        
    }
}
