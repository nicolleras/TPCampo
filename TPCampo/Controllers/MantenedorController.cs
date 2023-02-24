using Microsoft.AspNetCore.Mvc;
using System.Text;
using TPCampo.Data;
using TPCampo.Models;
using System.Security.Cryptography;


namespace TPCampo.Controllers
{
    public class MantenedorController : Controller
    {

        UsuarioDatos _UsuarioDatos = new UsuarioDatos();

        public IActionResult Listar()
        {
            //Esta vista muestra la lista de Usuarios
            var oLista = _UsuarioDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(UsuarioModel oUsuario)
        {
            //Este metodo recibe un objeto y lo guarda en la db
            //if (!ModelState.IsValid)
            //    return View();
            oUsuario.Contraseña = ConvertirSha256(oUsuario.Contraseña);
            oUsuario.TipoDocumento = "";
            oUsuario.ConfirmarContraseña = "";
            var respuesta = _UsuarioDatos.Guardar(oUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult CrearCuenta()
        {
            //Esto devuelve solamente la vista, el formulario HTML
            return View();
        }

        [HttpPost]
        public IActionResult CrearCuenta(UsuarioModel oUsuario)
        {
            //Este metodo recibe un objeto y lo guarda en la db
            if (!ModelState.IsValid)
                return View();

            var respuesta = _UsuarioDatos.Guardar(oUsuario);

            if (respuesta)
                return RedirectToAction("Index", "HomeUsuarioController");
            else
                return View();
        }

        public IActionResult Editar(int IdUsuario)
        {
            //Esta vista muestra la lista de Usuarios
            var oUsuario = _UsuarioDatos.Obtener(IdUsuario);
            return View(oUsuario);
        }
        [HttpPost]
        public IActionResult Editar(UsuarioModel oUsuario)
        {
            oUsuario.Contraseña = ConvertirSha256(oUsuario.Contraseña);
            oUsuario.TipoDocumento = "";
            oUsuario.ConfirmarContraseña = "";

            var respuesta = _UsuarioDatos.Editar(oUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Login(int IdUsuario)
        {
            //Esta vista muestra la lista de Usuarios
            var oUsuario = _UsuarioDatos.Obtener(IdUsuario);
            return View(oUsuario);
        }
        [HttpPost]
        public IActionResult Login(UsuarioModel oUsuario)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _UsuarioDatos.Login(oUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdUsuario)
        {
            //Esta vista muestra la lista de Usuarios
            var oUsuario = _UsuarioDatos.Obtener(IdUsuario);
            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Eliminar(UsuarioModel oUsuario)
        {

            var respuesta = _UsuarioDatos.Eliminar(oUsuario.IdUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public static string ConvertirSha256(string texto)
        {
            bool registrado;
            string mensaje;

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));

            }

            return Sb.ToString();
        }

    }
}
