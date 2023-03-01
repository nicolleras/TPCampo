using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorVehiculoController : Controller
    {

        VehiculoDatos _VehiculoDatos = new VehiculoDatos();
        ReservaDatos _ReservaDatos = new ReservaDatos();
        EmpresaProveedoraDatos _EmpresaProveedoraDatos = new EmpresaProveedoraDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Vehiculos
            var oLista = _VehiculoDatos.Listar();
            ViewBag.empresas = _EmpresaProveedoraDatos.Listar();

            return View(oLista);
        }

        public IActionResult ListarBusqueda(string? Destino, string? FechaInicio, string? FechaFin)
        {
            ViewBag.empresas = _EmpresaProveedoraDatos.Listar();
            List<ReservaModel> rLista = _ReservaDatos.Listar();
            List<VehiculoModel> vehiculosLista = _VehiculoDatos.Listar();
            List<int> listaIdVehiculos = new List<int>();
            var oLista = new List<VehiculoModel>();
            DateTime? fechaInicioBusqueda = null;
            DateTime? fechaFinBusqueda = null;
            BuscarModel buscarModel = new BuscarModel();
            if (TempData.Count != 0 || FechaInicio != null)
            {

                if (TempData.Count != 0)
                {
                    BuscarModel buscar = JsonConvert.DeserializeObject<BuscarModel>(TempData["mydata"].ToString());
                    fechaInicioBusqueda = DateTime.ParseExact(buscar.FechaInicio, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    fechaFinBusqueda = DateTime.ParseExact(buscar.FechaFin, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                }
                else
                {
                    fechaInicioBusqueda = DateTime.ParseExact(FechaInicio, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    fechaFinBusqueda = DateTime.ParseExact(FechaFin, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                }

                foreach (var reserva in rLista)
                {
                    var fechaInicioReserva = DateTime.ParseExact(reserva.FechaInicio, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    var fechaFinReserva = DateTime.ParseExact(reserva.FechaFin, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    int idVehiculo = (int)reserva.IdVehiculo;
                    bool disponible = false;

                    if ((fechaInicioBusqueda < fechaInicioReserva) && (fechaFinBusqueda < fechaInicioReserva))
                    {
                        disponible = true;
                    }

                    if (!disponible)
                    {
                        if ((fechaInicioBusqueda > fechaFinReserva) && (fechaFinBusqueda > fechaFinReserva))
                        {
                            disponible = true;
                        }
                    }

                    if (disponible)
                    {
                        if ((fechaInicioBusqueda > fechaInicioReserva) && (fechaInicioBusqueda < fechaFinReserva))
                        {
                            disponible = false;
                        }
                    }

                    if (disponible)
                    {
                        if ((fechaFinBusqueda > fechaInicioReserva) && (fechaFinBusqueda < fechaFinReserva))
                        {
                            disponible = false;
                        }
                    }


                    if (disponible)
                    {
                        if ((fechaInicioBusqueda < fechaInicioReserva) && (fechaFinBusqueda > fechaFinReserva))
                        {
                            disponible = false;
                        }
                    }

                    if (disponible)
                    {
                        bool has = oLista.Any(x => x.IdVehiculo == idVehiculo);
                        if (!has)
                        {
                            oLista.Add(_VehiculoDatos.Obtener((idVehiculo)));
                        }
                    }
                }

                foreach (var vehiculos in vehiculosLista)
                {
                    bool has = rLista.Any(x => x.IdVehiculo == vehiculos.IdVehiculo);
                    if (!has)
                    {
                        oLista.Add(_VehiculoDatos.Obtener(((int)vehiculos.IdVehiculo)));
                    }
                }


                /*foreach (var vehiculos in vehiculosLista)
                {
                    if (listaIdVehiculos.Count() != 0)
                    {
                        foreach (var vehiculo in listaIdVehiculos)
                        {
                            bool has = oLista.Any(x => x == vehiculos.IdVehiculo);
                            if (!has)
                            {
                                oLista.Add(_VehiculoDatos.Obtener(vehiculos.IdVehiculo));
                            }
                        }
                    }
                    else
                    {
                        oLista.Add(_VehiculoDatos.Obtener(vehiculos.IdVehiculo));
                    }

                }*/

                /* oLista = oLista.DistinctBy(x => x.IdVehiculo).ToList(); */

                Modelos modelos = new Modelos();
                //Esta vista muestra la lista de Vehiculos
                modelos.vehiculosModel = oLista;
                if (TempData.Count != 0)
                {
                    modelos.buscarModel = JsonConvert.DeserializeObject<BuscarModel>(TempData["mydata"].ToString());
                }
                else
                {
                    buscarModel.Destino = Destino;
                    buscarModel.FechaInicio = FechaInicio;
                    buscarModel.FechaFin = FechaFin;
                    modelos.buscarModel = buscarModel;
                }
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
            ViewBag.empresas = _EmpresaProveedoraDatos.Listar(); 
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(VehiculoModel oVehiculo)
        {
            ViewBag.empresas = _EmpresaProveedoraDatos.Listar();

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
            //Esta vista muestra la lista de vehiculos
            ViewBag.empresas = _EmpresaProveedoraDatos.Listar();
            var oVehiculo = _VehiculoDatos.Obtener(IdVehiculo);
            return View(oVehiculo);
        }
        [HttpPost]
        public IActionResult Editar(VehiculoModel oVehiculo)
        {
            ViewBag.empresas = _EmpresaProveedoraDatos.Listar();
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
            //Esta vista muestra la lista de vehiculos
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
