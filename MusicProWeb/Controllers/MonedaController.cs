using Microsoft.AspNetCore.Mvc;
using MusicProWeb.Models;
using Newtonsoft.Json;

//Consumo Api Monedas
namespace MusicProWeb.Controllers
{
    public class MonedaController : Controller
    {
        public IActionResult ListarMonedas()
        {
            var listado = new List<Moneda>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.gael.cloud/general/");

            var request = client.GetAsync("public/monedas").Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<Moneda>>(result);
            }


            return View(listado);
        }
    }
}
