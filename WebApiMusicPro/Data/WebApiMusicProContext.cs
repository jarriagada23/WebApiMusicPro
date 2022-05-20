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
    }
}
