using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MusicProWeb.Models;
using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicProWeb.Controllers
{
    public class UsuariosController : Controller
    {   
        
        public IActionResult ListarUsuarios()
        {   
            var listado = new List<Usuario>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/Usuarios").Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<Usuario>>(result);
            }


            return View(listado);
        }

        [HttpGet]

        public IActionResult NuevoUsuario()
        {
            Combobox();    
            return View();
        
        }
        [HttpPost]
        public IActionResult NuevoUsuario(Usuario usuario)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.PostAsync("api/Usuarios", usuario, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Usuario>(result);

                if (_user != null)
                {
                    return RedirectToAction("ListarUsuarios");

                }
                return View(usuario);
            }
            return View(usuario);

        }
        [HttpGet]

        public IActionResult ActualizarUsuario(int id)
        {
            Combobox();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/Usuarios/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Usuario>(result);
                return View(_user);
            }

            return View();

        }
        [HttpPost]
        public IActionResult ActualizarUsuario(int id ,Usuario usuario)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");
            var request = client.PutAsync("api/Usuarios/"+id, usuario, new JsonMediaTypeFormatter()).Result;

               
            return RedirectToAction("ListarUsuarios");

        }

        [HttpGet]

        public IActionResult EliminarUsuario(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.DeleteAsync("api/Usuarios/" + id).Result;
            return RedirectToAction("ListarUsuarios");

        } 
        public void Combobox()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "admin", Value = "admin" });
            lst.Add(new SelectListItem() { Text = "bodeguero", Value = "bodeguero" });
            lst.Add(new SelectListItem() { Text = "contador", Value = "contador" });
            lst.Add(new SelectListItem() { Text = "cliente", Value = "cliente" });

            ViewBag.Opciones = lst;
            
        }

        

           





        }
}




