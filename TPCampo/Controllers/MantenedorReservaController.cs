using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorReservaController : Controller
    {

        ReservaDatos _ReservaDatos = new ReservaDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Reservas
            var oLista = _ReservaDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ReservaModel oReserva)
        {
            //Este metodo recibe un objeto y lo guarda en la db
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ReservaDatos.Guardar(oReserva);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdReserva)
        {
            //Esta vista muestra la lista de Usuarios
            var oReserva = _ReservaDatos.Obtener(IdReserva);
            return View(oReserva);
        }
        [HttpPost]
        public IActionResult Editar(ReservaModel oReserva)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ReservaDatos.Editar(oReserva);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdReserva)
        {
            //Esta vista muestra la lista de Usuarios
            var oReserva = _ReservaDatos.Obtener(IdReserva);
            return View(oReserva);
        }

        [HttpPost]
        public IActionResult Eliminar(ReservaModel oReserva)
        {

            var respuesta = _ReservaDatos.Eliminar(oReserva.IdReserva);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
