﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System.Collections.Generic;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorVehiculoController : Controller
    {

        VehiculoDatos _VehiculoDatos = new VehiculoDatos();
        ReservaDatos _ReservaDatos = new ReservaDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Vehiculos
            var oLista = _VehiculoDatos.Listar();

            return View(oLista);
        }

        public IActionResult ListarBusqueda()
        {
            List<ReservaModel> rLista = _ReservaDatos.Listar();
            List<VehiculoModel> vehiculosLista = _VehiculoDatos.Listar();
            var oLista = new List<VehiculoModel>();
            if(TempData.Count != 0) { 
            BuscarModel buscar = JsonConvert.DeserializeObject<BuscarModel>(TempData["mydata"].ToString());
           

            foreach (var item in rLista){
                DateTime fechaInicioReserva = Convert.ToDateTime(item.FechaInicio);
                DateTime fechaFinReserva = Convert.ToDateTime(item.FechaFin);
                DateTime fechaInicioBusqueda = Convert.ToDateTime(buscar.FechaInicio);
                DateTime fechaFinBusqueda = Convert.ToDateTime(buscar.FechaFin);
                bool disponible = false;
                int idVehiculo = (int)item.IdVehiculo;

                if ((fechaFinBusqueda < fechaInicioReserva))
                {
                    bool has = oLista.Any(x => x.IdVehiculo == idVehiculo);
                    if (!has) { 
                        oLista.Add(_VehiculoDatos.Obtener(idVehiculo));
                    }
                        disponible = true;
                }
                if ((fechaInicioBusqueda > fechaFinReserva))
                {
                    bool has = oLista.Any(x => x.IdVehiculo == idVehiculo);
                    if (!has)
                    {
                        oLista.Add(_VehiculoDatos.Obtener(idVehiculo));
                    }
                        disponible = true;
                }
                if (!disponible)
                {
                        bool has = oLista.Any(x => x.IdVehiculo == idVehiculo);
                        if (has)
                        {
                            oLista.Remove(_VehiculoDatos.Obtener(idVehiculo));
                        }
                }
            }

            Modelos modelos = new Modelos();
            //Esta vista muestra la lista de Vehiculos
            modelos.vehiculosModel = vehiculosLista;
            modelos.buscarModel = JsonConvert.DeserializeObject<BuscarModel>(TempData["mydata"].ToString());

            return View(modelos);
            }
            else
            {
                return RedirectToAction("Buscar", "HomeUsuario");
            }
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
