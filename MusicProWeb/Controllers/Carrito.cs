using Microsoft.AspNetCore.Mvc;

namespace MusicPro4.Controllers
{
    public class CarritoController : Controller
    {
        
        public IActionResult Carrito()
        {
            return View();
        }
    }
}
