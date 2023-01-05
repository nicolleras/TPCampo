using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPCampo.Models;

namespace TPCampo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmpresaProveedora()
        {
            return View();
        }

        public IActionResult Vehiculos()
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