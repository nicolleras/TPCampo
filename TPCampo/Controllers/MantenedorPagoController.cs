﻿using Microsoft.AspNetCore.Mvc;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorPagoController : Controller
    {

        PagoDatos _PagoDatos = new PagoDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Pagos
            var oLista = _PagoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PagoModel oPago)
        {
            //Este metodo recibe un objeto y lo guarda en la db
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PagoDatos.Guardar(oPago);




            var _ReservaDatos = new ReservaDatos();
            var oReserva = new ReservaModel();

            int idReserva = (int) oPago.IdReserva;

            oReserva = _ReservaDatos.Obtener(idReserva);
            oReserva.Estado = "CONFIRMADA";       
            _ReservaDatos.Editar(oReserva);



            if (respuesta)
                return RedirectToAction("Listar");
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