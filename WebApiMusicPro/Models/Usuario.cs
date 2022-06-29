using System.ComponentModel.DataAnnotations;

//Creacion Clase Usuario 
namespace WebApiMusicPro.Models
{
    public class Usuario
    {   [Key]
        public int   idUsuario { get; set; }

        public string Rut { get; set; }

        public string nombre { get; set; }

        public string correo { get; set; }

        public string contraseña { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string tipo { get; set; }

        public string estado { get; set; }
    }
}
