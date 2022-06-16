using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicProWeb.Models
{
    public class Carrito
    {


        

        public string idCarrito { get; set; }

        public int Cantidad { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductId { get; set; }





    }
    
}




