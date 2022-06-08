using Microsoft.AspNetCore.Mvc;
using MusicPro.Models;
using System.Text.Json;

namespace MusicPro.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public UsuarioController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                var client = _httpClient.CreateClient("RestApi");
                var response = await client.GetAsync("Usuarios");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<GenericResponse>(content, options);
                    if (result.HttpCode == System.Net.HttpStatusCode.OK)
                        usuarios = JsonSerializer.Deserialize<List<Usuario>>(result.Data.ToString(), options);


                    return View(usuarios);
                }
                return View();

            }
            catch
            {
                return View("Error");
            }
        }


        // GET: EmployeesController/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = _httpClient.CreateClient("RestApi");
                    var response = await client.PostAsJsonAsync("Usuarios", usuario);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<GenericResponse>(content, options);
                        if (result.HttpCode == System.Net.HttpStatusCode.OK)
                            return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
