using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Principal;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorBuscarController : Controller
    {

        [HttpPost]
        public IActionResult Buscar(BuscarModel buscarModel)
        {
            //Esto devuelve solamente la vista, el formulario HTML
            //return RedirectToAction("ListarBusqueda", "MantenedorVehiculo",buscarModel);

            BuscarModel data = new BuscarModel()
            {
                Destino = buscarModel.Destino,
                FechaInicio = buscarModel.FechaInicio,
                FechaFin = buscarModel.FechaFin
            };

            TempData["mydata"] = JsonConvert.SerializeObject(data);


            return RedirectToAction("ListarBusqueda", "MantenedorVehiculo");
        }

    }
}