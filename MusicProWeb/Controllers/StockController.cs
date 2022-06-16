using Microsoft.AspNetCore.Mvc;
using MusicProWeb.Models;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace MusicProWeb.Controllers
{
    public class StockController : Controller
    {
        public IActionResult ListarStock()
        {
            var listado = new List<StockDTO>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/StockDTO").Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<StockDTO>>(result);
            }


            return View(listado);
        }
        [HttpGet]

        public IActionResult NuevoStock()
        {

            return View();

        }
        [HttpPost]
        public IActionResult NuevoStock(Stock stock)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.PostAsync("api/Stock", stock, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Usuario>(result);

                if (_user != null)
                {
                    return RedirectToAction("ListarStock");

                }
                return View(stock);
            }
            return View(stock);

        }
        [HttpGet]

        public IActionResult ActualizarStock(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.GetAsync("api/Stock/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var _user = JsonConvert.DeserializeObject<Stock>(result);
                return View(_user);
            }

            return View();

        }
        [HttpPost]
        public IActionResult ActualizarStock(int id, Stock stock)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");
            var request = client.PutAsync("api/Stock/" + id, stock, new JsonMediaTypeFormatter()).Result;


            return RedirectToAction("ListarStock");

        }

        [HttpGet]

        public IActionResult EliminarStock(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/");

            var request = client.DeleteAsync("api/Stock/" + id).Result;
            return RedirectToAction("ListarStock");

        }
    }
}
