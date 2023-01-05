using TPCampo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace TPCampo.Data
{
    public class ReservaDatos
    {

        public List<ReservaModel> Listar()
        {

            var oLista = new List<ReservaModel>();


            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarReservas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read() != false)
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new ReservaModel()
                            {
                                IdReserva = Convert.ToInt32(dr["IdReserva"]),
                                Destino = dr["Destino"].ToString(),
                                FechaInicio = dr["FechaInicio"].ToString(),
                                FechaFin = dr["FechaFin"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                MontoTotal = Convert.ToSingle(dr["MontoTotal"]),
                                IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]),
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            });

                        }
                    }
                }
            }
            return oLista;
        }


        public ReservaModel Obtener(int IdReserva)
        {

            var oReserva = new ReservaModel();

            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.getStringSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GetReserva", conexion);
                cmd.Parameters.AddWithValue("IdReserva", IdReserva);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oReserva.IdReserva = Convert.ToInt32(dr["IdReserva"]);
                        oReserva.Destino = dr["Destino"].ToString();
                        oReserva.FechaInicio = dr["FechaInicio"].ToString();
                        oReserva.FechaFin = dr["FechaFin"].ToString();
                        oReserva.Estado = dr["Estado"].ToString();
                        oReserva.MontoTotal = Convert.ToSingle(dr["MontoTotal"]);
                        oReserva.IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]);
                        oReserva.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    }

                }
            }

            return oReserva;
        }

        public bool Guardar(ReservaModel oReserva)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarReserva", conexion);
                    cmd.Parameters.AddWithValue("Destino", oReserva.Destino);
                    cmd.Parameters.AddWithValue("FechaInicio", oReserva.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", oReserva.FechaFin);
                    cmd.Parameters.AddWithValue("Estado", oReserva.Estado);
                    cmd.Parameters.AddWithValue("MontoTotal", oReserva.MontoTotal);
                    cmd.Parameters.AddWithValue("IdVehiculo", oReserva.IdVehiculo);
                    cmd.Parameters.AddWithValue("IdUsuario", oReserva.IdUsuario);
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


        public bool Editar(ReservaModel oReserva)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarReserva", conexion);
                    cmd.Parameters.AddWithValue("IdReserva", oReserva.IdReserva);
                    cmd.Parameters.AddWithValue("Destino", oReserva.Destino);
                    cmd.Parameters.AddWithValue("FechaInicio", oReserva.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", oReserva.FechaFin);
                    cmd.Parameters.AddWithValue("Estado", oReserva.Estado);
                    cmd.Parameters.AddWithValue("MontoTotal", oReserva.MontoTotal);
                    cmd.Parameters.AddWithValue("IdVehiculo", oReserva.IdVehiculo);
                    cmd.Parameters.AddWithValue("IdUsuario", oReserva.IdUsuario);
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


        public bool Eliminar(int IdReserva)
        {
            bool respuesta;

            try
            {
                var cn = new Connection();

                using (var conexion = new SqlConnection(cn.getStringSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarReserva", conexion);
                    cmd.Parameters.AddWithValue("IdReserva", IdReserva);
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