using Microsoft.AspNetCore.Mvc;
using MusicProWeb.Models;
using Newtonsoft.Json;

//Consumo Api Clima
namespace MusicProWeb.Controllers
{
    public class ClimaController : Controller
    {
        public IActionResult Clima()
        {
            var listado = new List<Clima>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.gael.cloud/general/");

            var request = client.GetAsync("public/clima").Result;

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<Clima>>(result);
            }


            return View(listado);
        }
    }
}
