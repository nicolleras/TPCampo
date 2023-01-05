using TPCampo.Models;
using System.Data.SqlClient;
using System.Data;

namespace TPCampo.Data
{
    public class VehiculoDatos
    {

        public List<VehiculoModel> Listar()
        {

            var oLista = new List<VehiculoModel>();


            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarVehiculos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new VehiculoModel()
                        {
                            IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]),
                            Marca = dr["Marca"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            Imagen = dr["Imagen"].ToString(),
                            PrecioPorDia = dr["PrecioPorDia"].ToString(),
                            CapacidadPasajeros = dr["CapacidadPasajeros"].ToString(),
                            CapacidadEquipaje = dr["CapacidadEquipaje"].ToString(),
                            TipoCaja = dr["TipoCaja"].ToString(),
                            CantidadDePuertas = Convert.ToInt32(dr["CantidadDePuertas"]),
                            AireAcondicionado = dr["AireAcondicionado"].ToString(),
                            TipoDeCobertura = dr["TipoDeCobertura"].ToString(),
                            KmHabilitado = Convert.ToInt32(dr["KmHabilitado"]),
                            IdEmpresaProveedora = Convert.ToInt32(dr["IdEmpresaProveedora"]),
                        });

                    }
                }
            }
            return oLista;
        }

        public VehiculoModel Obtener(int IdVehiculo)
        {

            var oVehiculo = new VehiculoModel();

            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GetVehiculo", conexion);
                cmd.Parameters.AddWithValue("IdVehiculo", IdVehiculo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oVehiculo.IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]);
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Imagen = dr["Imagen"].ToString();
                        oVehiculo.PrecioPorDia = dr["PrecioPorDia"].ToString();
                        oVehiculo.CapacidadPasajeros = dr["CapacidadPasajeros"].ToString();
                        oVehiculo.CapacidadEquipaje = dr["CapacidadEquipaje"].ToString();
                        oVehiculo.TipoCaja = dr["TipoCaja"].ToString();
                        oVehiculo.CantidadDePuertas = Convert.ToInt32(dr["CantidadDePuertas"]);
                        oVehiculo.AireAcondicionado = dr["AireAcondicionado"].ToString();
                        oVehiculo.TipoDeCobertura = dr["TipoDeCobertura"].ToString();
                        oVehiculo.KmHabilitado = Convert.ToInt32(dr["KmHabilitado"]);
                        oVehiculo.IdEmpresaProveedora = Convert.ToInt32(dr["IdEmpresaProveedora"]);
                    }

                }
            }

            return oVehiculo;
        }

        public bool Guardar(VehiculoModel oVehiculo)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Imagen", oVehiculo.Imagen);
                    cmd.Parameters.AddWithValue("PrecioPorDia", oVehiculo.PrecioPorDia);
                    cmd.Parameters.AddWithValue("CapacidadPasajeros", oVehiculo.CapacidadPasajeros);
                    cmd.Parameters.AddWithValue("CapacidadEquipaje", oVehiculo.CapacidadEquipaje);
                    cmd.Parameters.AddWithValue("TipoCaja", oVehiculo.TipoCaja);
                    cmd.Parameters.AddWithValue("CantidadDePuertas", oVehiculo.CantidadDePuertas);
                    cmd.Parameters.AddWithValue("AireAcondicionado", oVehiculo.AireAcondicionado);
                    cmd.Parameters.AddWithValue("TipoDeCobertura", oVehiculo.TipoDeCobertura);
                    cmd.Parameters.AddWithValue("KmHabilitado", oVehiculo.KmHabilitado);
                    cmd.Parameters.AddWithValue("IdEmpresaProveedora", oVehiculo.IdEmpresaProveedora);
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


        public bool Editar(VehiculoModel oVehiculo)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", oVehiculo.IdVehiculo);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Imagen", oVehiculo.Imagen);
                    cmd.Parameters.AddWithValue("PrecioPorDia", oVehiculo.PrecioPorDia);
                    cmd.Parameters.AddWithValue("CapacidadPasajeros", oVehiculo.CapacidadPasajeros);
                    cmd.Parameters.AddWithValue("CapacidadEquipaje", oVehiculo.CapacidadEquipaje);
                    cmd.Parameters.AddWithValue("TipoCaja", oVehiculo.TipoCaja);
                    cmd.Parameters.AddWithValue("CantidadDePuertas", oVehiculo.CantidadDePuertas);
                    cmd.Parameters.AddWithValue("AireAcondicionado", oVehiculo.AireAcondicionado);
                    cmd.Parameters.AddWithValue("TipoDeCobertura", oVehiculo.TipoDeCobertura);
                    cmd.Parameters.AddWithValue("KmHabilitado", oVehiculo.KmHabilitado);
                    cmd.Parameters.AddWithValue("IdEmpresaProveedora", oVehiculo.IdEmpresaProveedora);
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


        public bool Eliminar(int IdVehiculo)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", IdVehiculo);
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
