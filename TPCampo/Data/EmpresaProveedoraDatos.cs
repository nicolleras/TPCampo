using TPCampo.Models;
using System.Data.SqlClient;
using System.Data;

namespace TPCampo.Data
{
    public class EmpresaProveedoraDatos
    {

        public List<EmpresaProveedoraModel> Listar()
        {

            var oLista = new List<EmpresaProveedoraModel>();


            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEmpresasProveedoras", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new EmpresaProveedoraModel()
                        {
                            IdEmpresaProveedora = Convert.ToInt32(dr["IdEmpresaProveedora"]),
                            Nombre = dr["Nombre"].ToString(),
                            Logo = dr["Logo"].ToString(),
                            CalificacionPromedio = dr["CalificacionPromedio"].ToString(),
                          
                        });

                    }
                }
            }
            return oLista;
        }


        public EmpresaProveedoraModel Obtener(int IdEmpresaProveedora)
        {

            var oEmpresaProveedora = new EmpresaProveedoraModel();

            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GetEmpresaProveedora", conexion);
                cmd.Parameters.AddWithValue("IdEmpresaProveedora", IdEmpresaProveedora);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oEmpresaProveedora.IdEmpresaProveedora = Convert.ToInt32(dr["IdEmpresaProveedora"]);
                        oEmpresaProveedora.Nombre = dr["Nombre"].ToString();
                        oEmpresaProveedora.Logo = dr["Logo"].ToString();
                        oEmpresaProveedora.CalificacionPromedio = dr["CalificacionPromedio"].ToString();
                    }

                }
            }

            return oEmpresaProveedora;
        }

        public bool Guardar(EmpresaProveedoraModel oEmpresaProveedora)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarEmpresaProveedora", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oEmpresaProveedora.Nombre);
                    cmd.Parameters.AddWithValue("Logo", oEmpresaProveedora.Logo);
                    cmd.Parameters.AddWithValue("CalificacionPromedio", oEmpresaProveedora.CalificacionPromedio);
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


        public bool Editar(EmpresaProveedoraModel oEmpresaProveedora)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarEmpresaProveedora", conexion);
                    cmd.Parameters.AddWithValue("IdEmpresaProveedora", oEmpresaProveedora.IdEmpresaProveedora);
                    cmd.Parameters.AddWithValue("Nombre", oEmpresaProveedora.Nombre);
                    cmd.Parameters.AddWithValue("Logo", oEmpresaProveedora.Logo);
                    cmd.Parameters.AddWithValue("CalificacionPromedio", oEmpresaProveedora.CalificacionPromedio);
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


        public bool Eliminar(int IdEmpresaProveedora)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarEmpresaProveedora", conexion);
                    cmd.Parameters.AddWithValue("IdEmpresaProveedora", IdEmpresaProveedora);
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
