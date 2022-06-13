using Microsoft.AspNetCore.Mvc;
using MusicProWeb.Models;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace MusicProWeb.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListarProductos()
        {
            var listado = new List<Producto>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/Producto").Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<Producto>>(result);
            }


            return View(listado);
        }
        [HttpGet]

        public IActionResult NuevoProducto()
        {

            return View();

        }
        [HttpPost]
        public IActionResult NuevoProducto(Producto producto)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.PostAsync("api/Producto", producto, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Producto>(result);

                if (_user != null)
                {
                    return RedirectToAction("ListarProductos");

                }
                return View(producto);
            }
            return View(producto);

        }
        [HttpGet]

        public IActionResult ActualizarProducto(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/Producto/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Producto>(result);
                return View(_user);
            }

            return View();

        }
        [HttpPost]
        public IActionResult ActualizarProducto(int id, Producto producto)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");
            var request = client.PutAsync("api/Producto/" + id, producto, new JsonMediaTypeFormatter()).Result;

            return RedirectToAction("ListarProductos");

        }
        [HttpGet]

        public IActionResult EliminarProducto(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.DeleteAsync("api/Producto/" + id).Result;
            return RedirectToAction("ListarProductos");

        }

        public IActionResult DetalleProducto(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/Producto/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Producto>(result);
                return View(_user);
            }

            return View();

        }
    }
}
