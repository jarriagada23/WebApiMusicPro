using Microsoft.AspNetCore.Mvc;
using MusicProWeb.Models;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace MusicProWeb.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult ListarVenta()
        {
            var listado = new List<VentaDTO>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/VentaDTO").Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<VentaDTO>>(result);
            }


            return View(listado);
        }
        [HttpGet]

        public IActionResult NuevaVenta()
        {

            return View();

        }
        [HttpPost]
        public IActionResult NuevaVenta(Venta venta)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.PostAsync("api/Ventas", venta, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Usuario>(result);

                if (_user != null)
                {
                    return RedirectToAction("ListarVenta");

                }
                return View(venta);
            }
            return View(venta);

        }
        [HttpGet]

        public IActionResult ActualizarVenta(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/Ventas/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Venta>(result);
                return View(_user);
            }

            return View();

        }
        [HttpPost]
        public IActionResult ActualizarVenta(int id, Venta venta)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");
            var request = client.PutAsync("api/Ventas/" + id, venta, new JsonMediaTypeFormatter()).Result;


            return RedirectToAction("ListarVenta");

        }
        [HttpGet]

        public IActionResult EliminarVenta(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.DeleteAsync("api/Ventas/" + id).Result;
            return RedirectToAction("ListarVenta");

        }
    }
}

