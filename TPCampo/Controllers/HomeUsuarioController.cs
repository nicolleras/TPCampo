using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPCampo.Models;

namespace TPCampo.Controllers
{
    public class HomeUsuarioController : Controller
    {
        private readonly ILogger<HomeUsuarioController> _logger;

        public HomeUsuarioController(ILogger<HomeUsuarioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}