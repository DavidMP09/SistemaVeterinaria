using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Veterinaria.Models
{
    public class DaoHistorial
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<EntidadHistorial> listar()
        {

            List<EntidadHistorial> listado = new List<EntidadHistorial>();

            try
            {

                SqlCommand cmd = new SqlCommand("usp_listarhistorial", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    EntidadHistorial historial = new EntidadHistorial();
                    historial.idhistorial = int.Parse(dr.GetValue(0).ToString());
                    historial.fecha = dr.GetValue(1).ToString();
                    historial.tratamientos = dr.GetValue(2).ToString();
                    historial.enfermedad = dr.GetValue(3).ToString();
                    historial.evulucion= dr.GetValue(4).ToString();
                    listado.Add(historial);
                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return listado;
        }
        public bool guardar(EntidadHistorial historial)
        {

                int id = 0;
                SqlCommand cmd = new SqlCommand("usp_insertarhistorial", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", historial.fecha);
                cmd.Parameters.AddWithValue("@tratamientos", historial.tratamientos);
                cmd.Parameters.AddWithValue("@enfermedad", historial.enfermedad);
                cmd.Parameters.AddWithValue("@evulucion", historial.evulucion);
                conn.Open();
                id=cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();

            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //buscar por id historial
        public EntidadHistorial buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarhistorialID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                EntidadHistorial historial = new EntidadHistorial();
                while (dr.Read())
                {
                    historial.idhistorial = int.Parse(dr.GetValue(0).ToString());
                    historial.fecha = dr.GetValue(1).ToString();
                    historial.tratamientos = dr.GetValue(2).ToString();
                    historial.enfermedad = dr.GetValue(3).ToString();
                    historial.evulucion = dr.GetValue(4).ToString();
                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return historial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public bool actualizarhistorial(EntidadHistorial historial)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("ups_actualizarhistorial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", historial.fecha);
            cmd.Parameters.AddWithValue("@tratamientos", historial.tratamientos);
            cmd.Parameters.AddWithValue("@enfermedad", historial.enfermedad);
            cmd.Parameters.AddWithValue("@evulucion", historial.evulucion);
            cmd.Parameters.AddWithValue("@idhistorial", historial.idhistorial);
            conn.Open();
            i = cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //borar historial
        public string borrarhistorial(int id)
        {

            string resultado = "";
            SqlCommand cmd = new SqlCommand("usp_borrarhistorial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idhistorial", id);
            cmd.Parameters.Add("@mensajesalida", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            resultado = cmd.Parameters["@mensajesalida"].Value.ToString();
            conn.Close();
            cmd.Dispose();

            return resultado;
        }

    }
}