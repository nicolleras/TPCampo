using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorVehiculoController : Controller
    {

        VehiculoDatos _VehiculoDatos = new VehiculoDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Vehiculos
            var oLista = _VehiculoDatos.Listar();

            return View(oLista);
        }

        public IActionResult ListarBusqueda()
        {
            Modelos modelos = new Modelos();
            //Esta vista muestra la lista de Vehiculos
            modelos.vehiculosModel = _VehiculoDatos.Listar();
            modelos.buscarModel = JsonConvert.DeserializeObject<BuscarModel>(TempData["mydata"].ToString());

            return View(modelos);
        }

        public IActionResult Guardar()
        {
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(VehiculoModel oVehiculo)
        {
            //Este metodo recibe un objeto y lo guarda en la db
            if (!ModelState.IsValid)
                return View();

            var respuesta = _VehiculoDatos.Guardar(oVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdVehiculo)
        {
            //Esta vista muestra la lista de Usuarios
            var oVehiculo = _VehiculoDatos.Obtener(IdVehiculo);
            return View(oVehiculo);
        }
        [HttpPost]
        public IActionResult Editar(VehiculoModel oVehiculo)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _VehiculoDatos.Editar(oVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdVehiculo)
        {
            //Esta vista muestra la lista de Usuarios
            var oVehiculo = _VehiculoDatos.Obtener(IdVehiculo);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult Eliminar(VehiculoModel oVehiculo)
        {

            var respuesta = _VehiculoDatos.Eliminar(oVehiculo.IdVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
