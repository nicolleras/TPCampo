using TPCampo.Models;
using System.Data.SqlClient;
using System.Data;

namespace TPCampo.Data
{
    public class UsuarioDatos
    {

        public List<UsuarioModel> Listar()
        {

            var oLista = new List<UsuarioModel>();


            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new UsuarioModel()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Email = dr["Email"].ToString(),
                            Contraseña = dr["Contraseña"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            FechaNacimiento = dr["FechaNacimiento"].ToString(),
                            TipoDocumento = dr["TipoDocumento"].ToString(),
                            Dni = Convert.ToInt32(dr["Dni"]),
                            Telefono = (int?)Convert.ToInt64(dr["Telefono"]),
                        });

                    }
                }
            }
            return oLista;
        }


        public UsuarioModel Obtener(int IdUsuario)
        {

            var oUsuario = new UsuarioModel();

            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GetUsuario", conexion);
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        oUsuario.Nombre = dr["Nombre"].ToString();
                        oUsuario.Apellido = dr["Apellido"].ToString();
                        oUsuario.Email = dr["Email"].ToString();
                        oUsuario.Contraseña = dr["Contraseña"].ToString();
                        oUsuario.Rol = dr["Rol"].ToString();
                        oUsuario.FechaNacimiento = dr["FechaNacimiento"].ToString();
                        oUsuario.TipoDocumento = dr["TipoDocumento"].ToString(); 
                        oUsuario.Dni = Convert.ToInt32(dr["Dni"]);
                        oUsuario.Telefono = (int?)Convert.ToInt64(dr["Telefono"]);
                    }

                }
            }

            return oUsuario;
        }

        public bool Guardar(UsuarioModel oUsuario)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oUsuario.Apellido);
                    cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("Rol", oUsuario.Rol);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oUsuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("TipoDocumento", oUsuario.TipoDocumento);
                    cmd.Parameters.AddWithValue("Dni", oUsuario.Dni);
                    cmd.Parameters.AddWithValue("Telefono", oUsuario.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool CrearCuenta(UsuarioModel oUsuario)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oUsuario.Apellido);
                    cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("Rol", oUsuario.Rol);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oUsuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("TipoDocumento", oUsuario.TipoDocumento);
                    cmd.Parameters.AddWithValue("Dni", oUsuario.Dni);
                    cmd.Parameters.AddWithValue("Telefono", oUsuario.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool Editar(UsuarioModel oUsuario)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oUsuario.Apellido);
                    cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("Rol", oUsuario.Rol);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oUsuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("TipoDocumento", oUsuario.TipoDocumento);
                    cmd.Parameters.AddWithValue("Dni", oUsuario.Dni);
                    cmd.Parameters.AddWithValue("Telefono", oUsuario.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Login(UsuarioModelLogin oUsuario)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oUsuario.Apellido);
                    cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("Rol", oUsuario.Rol);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oUsuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("TipoDocumento", oUsuario.TipoDocumento);
                    cmd.Parameters.AddWithValue("Dni", oUsuario.Dni);
                    cmd.Parameters.AddWithValue("Telefono", oUsuario.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int IdUsuario)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
