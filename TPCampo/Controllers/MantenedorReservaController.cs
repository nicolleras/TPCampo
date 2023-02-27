using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection;
using TPCampo.Data;
using TPCampo.Models;
using System.Diagnostics;


namespace TPCampo.Controllers
{
    public class MantenedorReservaController : Controller
    {

        ReservaDatos _ReservaDatos = new ReservaDatos();
        VehiculoDatos _VehiculoDatos = new VehiculoDatos();
        UsuarioDatos _UsuarioDatos = new UsuarioDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Reservas

            ModeloReservasVehiculos modelos = new ModeloReservasVehiculos();
            modelos.reservaModel = _ReservaDatos.Listar();
            modelos.vehiculosModel = _VehiculoDatos.Listar();
            ViewBag.vehiculos = _VehiculoDatos.Listar();
            ViewBag.usuarios = _UsuarioDatos.Listar();

            return View(modelos);
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


        public IActionResult ElegirReserva(int IdVehiculo, String Destino, String FechaInicio, String FechaFin, float PrecioPorDia)
        {

            DateTime fechaInicio = Convert.ToDateTime(FechaInicio);
            DateTime fechaFin = Convert.ToDateTime(FechaFin);

            TimeSpan difFechas = fechaFin - fechaInicio;
            int dias = difFechas.Days;

            var reservaParcialModel = new ReservaParcialModel();

            ViewBag.IdVehiculo = IdVehiculo;
            ViewBag.Destino = Destino;
            ViewBag.FechaInicio = FechaInicio;
            ViewBag.FechaFin = FechaFin;
            ViewBag.MontoTotal = PrecioPorDia * dias;

            reservaParcialModel.IdVehiculo = IdVehiculo;
            reservaParcialModel.Destino = Destino;
            reservaParcialModel.FechaInicio = FechaInicio;
            reservaParcialModel.FechaFin = FechaFin;
            reservaParcialModel.MontoTotal = PrecioPorDia * dias;

            return View();
        }

        [HttpPost]
        public IActionResult ReservarConfirmar(ReservaParcialModel reservaParcial)
        {
            var _ReservaDatos = new ReservaDatos();
            var oReserva = new ReservaModel();

            //System.Diagnostics.Debug.WriteLine(IdVehiculo);
            //System.Diagnostics.Debug.WriteLine(Modelo);
            //Page.Response.WriteAsJsonAsync("<script>console.log('" + Modelo + "');</script>");
            //Debug.Write(Modelo);
            //System.Diagnostics.Debug.WriteLine(Modelo);

            oReserva.Destino = reservaParcial.Destino;
            oReserva.FechaInicio = reservaParcial.FechaInicio;
            oReserva.FechaFin = reservaParcial.FechaFin;
            oReserva.Estado = "PENDIENTE";
            oReserva.MontoTotal = reservaParcial.MontoTotal;
            oReserva.IdVehiculo = reservaParcial.IdVehiculo;
            oReserva.IdUsuario = GlobalUser.IdUsuario;     
            
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
