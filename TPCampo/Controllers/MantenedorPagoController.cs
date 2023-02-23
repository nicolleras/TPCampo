using Microsoft.AspNetCore.Mvc;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorPagoController : Controller
    {

        PagoDatos _PagoDatos = new PagoDatos();
        ReservaDatos _ReservaDatos = new ReservaDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Pagos
            var rLista = _ReservaDatos.Listar();
            var pLista = _PagoDatos.Listar();
            var reservaLista = new List<ReservaModel>();
            var oLista = new List<PagoModel>();

            foreach (var item in rLista)
            {
                if (item.IdUsuario == GlobalUser.IdUsuario)
                {
                    reservaLista.Add(_ReservaDatos.Obtener((int)item.IdReserva));
                }
            }

            if (reservaLista.Any())
            {
                foreach (var reservaItem in reservaLista)
                {
                    foreach (var pagoItem in pLista)
                    {
                        if (reservaItem.IdReserva == pagoItem.IdReserva)
                        {
                            bool has = oLista.Any(x => x.IdPago == pagoItem.IdPago);
                            if (!has)
                            {
                                oLista.Add(_PagoDatos.Obtener(pagoItem.IdPago));
                            }
                        }
                    }
                }
            }

            return View(oLista);
        }

        public IActionResult Guardar(int idReserva, float montoTotal, string estado)
        {
            ViewBag.idReserva = idReserva;
            ViewBag.montoTotal = montoTotal;
            ViewBag.estado = estado;
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PagoModel oPago)
        {
            //Este metodo recibe un objeto y lo guarda en la db
            if (!ModelState.IsValid)
                return View();
            oPago.Estado = "CONFIRMADO";
            int idReserva = (int) oPago.IdReserva;

            if (_PagoDatos.Guardar(oPago))
            {
                var oReserva = new ReservaModel();
                var _ReservaDatos = new ReservaDatos();
                oReserva = _ReservaDatos.Obtener(idReserva);
                oReserva.Estado = "CONFIRMADA";
                _ReservaDatos.Editar(oReserva);
                return RedirectToAction("Listar");
            }
            else
                return View();
        }

        public IActionResult Editar(int IdPago)
        {
            //Esta vista muestra la lista de Usuarios
            var oPago = _PagoDatos.Obtener(IdPago);
            return View(oPago);
        }
        [HttpPost]
        public IActionResult Editar(PagoModel oPago)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PagoDatos.Editar(oPago);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdPago)
        {
            //Esta vista muestra la lista de Usuarios
            var oPago = _PagoDatos.Obtener(IdPago);
            return View(oPago);
        }

        [HttpPost]
        public IActionResult Eliminar(PagoModel oPago)
        {

            var respuesta = _PagoDatos.Eliminar(oPago.IdPago);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}