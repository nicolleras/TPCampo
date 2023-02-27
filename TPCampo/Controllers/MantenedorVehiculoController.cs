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

        public IActionResult ListarBusqueda()
        {
            ViewBag.empresas = _EmpresaProveedoraDatos.Listar();
            List<ReservaModel> rLista = _ReservaDatos.Listar();
            List<VehiculoModel> vehiculosLista = _VehiculoDatos.Listar();
            List<int> listaIdVehiculos = new List<int>(); 
            var oLista = new List<VehiculoModel>();
            if(TempData.Count != 0) { 
            BuscarModel buscar = JsonConvert.DeserializeObject<BuscarModel>(TempData["mydata"].ToString());

                var fechaInicioBusqueda = DateTime.ParseExact(buscar.FechaInicio,"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                var fechaFinBusqueda = DateTime.ParseExact(buscar.FechaFin, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

                foreach (var reserva in rLista)
                {
                    var fechaInicioReserva = DateTime.ParseExact(reserva.FechaInicio, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    var fechaFinReserva = DateTime.ParseExact(reserva.FechaFin, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    int idVehiculo = (int)reserva.IdVehiculo;
                    bool disponible = false;

                        if ((fechaFinBusqueda < fechaInicioReserva))
                        {
                            bool has = oLista.Any(x => x.IdVehiculo == idVehiculo);
                            if (!has)
                            {
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
                        bool tiene = listaIdVehiculos.Any(x => x == idVehiculo);
                        if (!tiene)
                        {
                            listaIdVehiculos.Add(idVehiculo);
                        }

                }

                foreach(var vehiculos in vehiculosLista)
                {
                    foreach (var vehiculo in listaIdVehiculos)
                    {
                        bool has = listaIdVehiculos.Any(x => x == vehiculos.IdVehiculo);
                        if (!has)
                        {
                            oLista.Add(_VehiculoDatos.Obtener(vehiculos.IdVehiculo));
                        }
                    }
                }

            Modelos modelos = new Modelos();
            //Esta vista muestra la lista de Vehiculos
            modelos.vehiculosModel = oLista;
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
