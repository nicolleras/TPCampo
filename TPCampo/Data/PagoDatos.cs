using TPCampo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace TPCampo.Data
{
    public class PagoDatos
    {

        public List<PagoModel> Listar()
        {

            var oLista = new List<PagoModel>();


            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarPagos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                        while (dr.Read())
                        {
                            oLista.Add(new PagoModel()
                            {
                                IdPago = Convert.ToInt32(dr["IdPago"]),
                                MontoFinal = Convert.ToSingle(dr["MontoFinal"]),
                                Estado = dr["Estado"].ToString(),
                                ServicioPago = dr["ServicioPago"].ToString(),
                                MedioPago = dr["MedioPago"].ToString(),
                                UltimosCuatro = Convert.ToInt32(dr["UltimosCuatro"]),
                                Cuotas = Convert.ToInt32(dr["Cuotas"]),
                                CodigoBarras = Convert.ToInt32(dr["CodigoBarras"]),
                                Cvu = Convert.ToInt32(dr["Cvu"]),
                                IdReserva = Convert.ToInt32(dr["IdReserva"]),
                            });

                        }
                }
            }
            return oLista;
        }


        public PagoModel Obtener(int IdPago)
        {

            var oPago = new PagoModel();

            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GetPago", conexion);
                cmd.Parameters.AddWithValue("IdPago", IdPago);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oPago.IdPago = Convert.ToInt32(dr["IdPago"]);
                        oPago.MontoFinal = Convert.ToSingle(dr["MontoFinal"]);
                        oPago.Estado = dr["Estado"].ToString();
                        oPago.ServicioPago = dr["ServicioPago"].ToString();
                        oPago.MedioPago = dr["MedioPago"].ToString();
                        oPago.UltimosCuatro = Convert.ToInt32(dr["UltimosCuatro"]);
                        oPago.Cuotas = Convert.ToInt32(dr["Cuotas"]);
                        oPago.CodigoBarras = Convert.ToInt32(dr["CodigoBarras"]);
                        oPago.Cvu = Convert.ToInt32(dr["Cvu"]);
                        oPago.IdReserva = Convert.ToInt32(dr["IdReserva"]);
                    }

                }
            }

            return oPago;
        }

        public bool Guardar(PagoModel oPago)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPago", conexion);
                    cmd.Parameters.AddWithValue("MontoFinal", oPago.MontoFinal);
                    cmd.Parameters.AddWithValue("Estado", oPago.Estado);
                    cmd.Parameters.AddWithValue("ServicioPago", oPago.ServicioPago);
                    cmd.Parameters.AddWithValue("MedioPago", oPago.MedioPago);
                    cmd.Parameters.AddWithValue("UltimosCuatro", oPago.UltimosCuatro);
                    cmd.Parameters.AddWithValue("Cuotas", oPago.Cuotas);
                    cmd.Parameters.AddWithValue("CodigoBarras", oPago.CodigoBarras);
                    cmd.Parameters.AddWithValue("Cvu", oPago.Cvu);
                    cmd.Parameters.AddWithValue("IdReserva", oPago.IdReserva);
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


        public bool Editar(PagoModel oPago)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarPago", conexion);
                    cmd.Parameters.AddWithValue("IdPago", oPago.IdPago);
                    cmd.Parameters.AddWithValue("MontoFinal", oPago.MontoFinal);
                    cmd.Parameters.AddWithValue("Estado", oPago.Estado);
                    cmd.Parameters.AddWithValue("ServicioPago", oPago.ServicioPago);
                    cmd.Parameters.AddWithValue("MedioPago", oPago.MedioPago);
                    cmd.Parameters.AddWithValue("UltimosCuatro", oPago.UltimosCuatro);
                    cmd.Parameters.AddWithValue("Cuotas", oPago.Cuotas);
                    cmd.Parameters.AddWithValue("CodigoBarras", oPago.CodigoBarras);
                    cmd.Parameters.AddWithValue("Cvu", oPago.Cvu);
                    cmd.Parameters.AddWithValue("IdReserva", oPago.IdReserva);
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


        public bool Eliminar(int IdPago)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarPago", conexion);
                    cmd.Parameters.AddWithValue("IdPago", IdPago);
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
