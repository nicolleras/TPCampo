﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using TPCampo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using TPCampo.Data;
using Microsoft.CodeAnalysis.Scripting;

namespace TPCampo.Controllers
{

    public class AccesoController : Controller
    {

         public ActionResult Login()
         {
             return View();
         }

         public IActionResult Registrar()
         {
             return View();
         }

         [HttpPost]
         public ActionResult Registrar(UsuarioModel oUsuario)
         {
             bool registrado;
             string mensaje;

             if (oUsuario.Contraseña == oUsuario.ConfirmarContraseña)
             {

                 oUsuario.Contraseña = ConvertirSha256(oUsuario.Contraseña);

             }
             else
             {
                 ViewData["Mensaje"] = "Las contraseñas no coinciden";
                 return View();
             }

             var cn = new Connection();

             using (var conexion = new SqlConnection(cn.getStringSQL()))
             {
                 conexion.Open();
                 SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conexion);
                 cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                 cmd.Parameters.AddWithValue("Apellido", oUsuario.Apellido);
                 cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                 cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                 cmd.Parameters.AddWithValue("Rol", "Cliente");
                 cmd.Parameters.AddWithValue("FechaNacimiento", oUsuario.FechaNacimiento);
                 cmd.Parameters.AddWithValue("TipoDocumento", oUsuario.TipoDocumento);
                 cmd.Parameters.AddWithValue("Dni", oUsuario.Dni);
                 cmd.Parameters.AddWithValue("Telefono", oUsuario.Telefono);
                 cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                 cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                 cmd.CommandType = CommandType.StoredProcedure;


                 cmd.ExecuteNonQuery();

                 registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                 mensaje = cmd.Parameters["Mensaje"].Value.ToString();

             }

             ViewData["Mensaje"] = mensaje;

             if (registrado)
             {
                 return RedirectToAction("Login", "Acceso");
             }
             else
             {
                 return View();
             }


         }

         [HttpPost]
         public ActionResult Login(UsuarioModel oUsuario)
         {

             oUsuario.Contraseña = ConvertirSha256(oUsuario.Contraseña);
             var cn = new Connection();

             using (var conexion = new SqlConnection(cn.getStringSQL()))
             {
                 conexion.Open();
                 SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conexion);
                 cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                 cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);

                 cmd.CommandType = CommandType.StoredProcedure;

                 oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());             
               
            }

             if (oUsuario.IdUsuario != 0)
             {
                GlobalUser.IdUsuario = oUsuario.IdUsuario;
                return RedirectToAction("Index", "HomeUsuario");
             }
             else
             {
                 ViewData["Mensaje"] = "Usuario no encontrado";
                 return View();
             }

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
