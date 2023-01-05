using Microsoft.AspNetCore.Mvc;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorBuscarController : Controller
    {


        public IActionResult Buscar()
        {
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

    }
}