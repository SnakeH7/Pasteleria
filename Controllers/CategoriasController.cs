using Microsoft.AspNetCore.Mvc;

namespace Pasteleria.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
