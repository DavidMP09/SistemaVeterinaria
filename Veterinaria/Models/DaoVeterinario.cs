using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Veterinaria.Models
{
    public class DaoVeterinario
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public List<EntidadVeterinario> listar()
        {

            List<EntidadVeterinario> listado = new List<EntidadVeterinario>();

            try
            {

                SqlCommand cmd = new SqlCommand("usp_listarveterinario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    EntidadVeterinario veterinario = new EntidadVeterinario();
                    veterinario.idveterinario = int.Parse(dr.GetValue(0).ToString());
                    veterinario.nombre = dr.GetValue(1).ToString();
                    veterinario.apellido = dr.GetValue(2).ToString();
                    veterinario.especialidad = dr.GetValue(3).ToString();
                    veterinario.telefono = dr.GetValue(4).ToString();
                    veterinario.correo = dr.GetValue(5).ToString();
                    listado.Add(veterinario);
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
        public bool guardar(EntidadVeterinario veterinario)
        {
                int id = 0;
                SqlCommand cmd = new SqlCommand("usp_insertarveterinario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", veterinario.nombre);
                cmd.Parameters.AddWithValue("@apellido", veterinario.apellido);
                cmd.Parameters.AddWithValue("@especialidad", veterinario.especialidad);
                cmd.Parameters.AddWithValue("@telefono", veterinario.telefono);
                cmd.Parameters.AddWithValue("@correo", veterinario.correo);
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
        public EntidadVeterinario buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarveterinarioID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                EntidadVeterinario veterinario = new EntidadVeterinario();
                while (dr.Read())
                {
                    veterinario.idveterinario = int.Parse(dr.GetValue(0).ToString());
                    veterinario.nombre = dr.GetValue(1).ToString();
                    veterinario.apellido = dr.GetValue(2).ToString();
                    veterinario.especialidad = dr.GetValue(3).ToString();
                    veterinario.telefono = dr.GetValue(4).ToString();
                    veterinario.correo = dr.GetValue(5).ToString();

                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return veterinario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public bool actualizarveterinario(EntidadVeterinario veterinario)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("ups_actualizaveterinario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", veterinario.nombre);
            cmd.Parameters.AddWithValue("@apellido", veterinario.apellido);
            cmd.Parameters.AddWithValue("@especialidad", veterinario.especialidad);
            cmd.Parameters.AddWithValue("@telefono", veterinario.telefono);
            cmd.Parameters.AddWithValue("@correo", veterinario.correo);
            cmd.Parameters.AddWithValue("@idveterinario", veterinario.idveterinario);
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
        public string borrarveterinario(int id)
        {

            string resultado = "";
            SqlCommand cmd = new SqlCommand("usp_borrarveterinario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idveterinario", id);
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