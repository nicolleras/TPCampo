using Microsoft.AspNetCore.Mvc;
using TPCampo.Data;
using TPCampo.Models;


namespace TPCampo.Controllers
{
    public class MantenedorEmpresaProveedoraController : Controller
    {

        EmpresaProveedoraDatos _EmpresaProveedoraDatos = new EmpresaProveedoraDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de EmpresaProveedora
            var oLista = _EmpresaProveedoraDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EmpresaProveedoraModel oEmpresaProveedora)
        {
            //Este metodo recibe un objeto y lo guarda en la db
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpresaProveedoraDatos.Guardar(oEmpresaProveedora);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        
        public IActionResult Editar(int IdEmpresaProveedora)
        {
            //Esta vista muestra la lista de EmpresaProveedora
            var oEmpresaProveedora = _EmpresaProveedoraDatos.Obtener(IdEmpresaProveedora);
            return View(oEmpresaProveedora);
        }
        [HttpPost]
        public IActionResult Editar(EmpresaProveedoraModel oEmpresaProveedora)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpresaProveedoraDatos.Editar(oEmpresaProveedora);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdEmpresaProveedora)
        {
            //Esta vista muestra la lista de EmpresaProveedora
            var oEmpresaProveedora = _EmpresaProveedoraDatos.Obtener(IdEmpresaProveedora);
            return View(oEmpresaProveedora);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpresaProveedoraModel oEmpresaProveedora)
        {

            var respuesta = _EmpresaProveedoraDatos.Eliminar(oEmpresaProveedora.IdEmpresaProveedora);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
