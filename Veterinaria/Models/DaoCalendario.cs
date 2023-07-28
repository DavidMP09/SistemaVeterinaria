using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Veterinaria.Models
{
    public class DaoCalendario
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<EntidadCalendario> listar()
        {

            List<EntidadCalendario> listado = new List<EntidadCalendario>();

            try
            {

                SqlCommand cmd = new SqlCommand("usp_listarcalendario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    EntidadCalendario calendario = new EntidadCalendario();
                    calendario.idcalendario = int.Parse(dr.GetValue(0).ToString());
                    calendario.fecha = dr.GetValue(1).ToString();
                    calendario.enfermedad = dr.GetValue(2).ToString();
                    listado.Add(calendario);
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
        public bool guardar(EntidadCalendario calendario)
        {
            try
            {
                int id = 0;
                SqlCommand cmd = new SqlCommand("usp_insertarcalendario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", calendario.fecha);
                cmd.Parameters.AddWithValue("@enfer", calendario.enfermedad);
                conn.Open();
                id = cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //buscar x ID calendanrio
        public EntidadCalendario buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarcalendarioID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                EntidadCalendario calendario = new EntidadCalendario();
                while (dr.Read())
                {
                    calendario.idcalendario = int.Parse(dr.GetValue(0).ToString());
                    calendario.fecha = dr.GetValue(1).ToString();
                    calendario.enfermedad = dr.GetValue(2).ToString();
                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return calendario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        //actualizar
        public bool actualizarcalendario(EntidadCalendario calendario)
        {
            try
            {
                int i = 0;
                SqlCommand cmd = new SqlCommand("ups_actualizacalendario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", calendario.fecha);
                cmd.Parameters.AddWithValue("@enfer", calendario.enfermedad);
                cmd.Parameters.AddWithValue("@idcalendario", calendario.idcalendario);
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

           
        }
        public string borrarcalendario(int id)
        {

            try
            {
                string resultado = "";
                SqlCommand cmd = new SqlCommand("usp_borrarcalendario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcalendario", id);
                cmd.Parameters.Add("@mensajesalida", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                resultado = cmd.Parameters["@mensajesalida"].Value.ToString();
                conn.Close();
                cmd.Dispose();

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}