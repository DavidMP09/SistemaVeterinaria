using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Veterinaria.Models
{
    public class DaoCitas
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<EntidadCitas> listar()
        {

            List<EntidadCitas> listado = new List<EntidadCitas>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_listarcita", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EntidadCitas citas = new EntidadCitas();
                    citas.idcitas = int.Parse(dr.GetValue(0).ToString());
                    citas.fechar = dr.GetValue(1).ToString();
                    citas.hora = dr.GetValue(2).ToString();
                    citas.estado = dr.GetValue(3).ToString();
                    citas.cliente.nombre =dr.GetValue(4).ToString();
                    citas.servicios.nombre =dr.GetValue(5).ToString();
                    citas.mascota.nombre=dr.GetValue(6).ToString();
                    citas.veterinario.nombre =dr.GetValue(7).ToString();
                    listado.Add(citas);
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
        public bool guardar(EntidadCitas citas)
        {

            try
            {
                int id = 0;
                SqlCommand cmd = new SqlCommand("usp_insertarcita", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", citas.fechar);
                cmd.Parameters.AddWithValue("@hora", citas.hora);
                cmd.Parameters.AddWithValue("@estado", citas.estado);
                cmd.Parameters.AddWithValue("@idcliente", citas.cliente.idcliente);
                cmd.Parameters.AddWithValue("@idservicios", citas.servicios.idservicios);
                cmd.Parameters.AddWithValue("@idmascota", citas.mascota.idmascota);
                cmd.Parameters.AddWithValue("@idveterinario", citas.veterinario.idveterinario);
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
        public EntidadCitas buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarcitasID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                EntidadCitas citas = new EntidadCitas();
                while (dr.Read())
                {
                    citas.idcitas = int.Parse(dr.GetValue(0).ToString());
                    citas.fechar = dr.GetValue(1).ToString();
                    citas.hora = dr.GetValue(2).ToString();
                    citas.estado = dr.GetValue(3).ToString();
                    citas.cliente.nombre = dr.GetValue(4).ToString();
                    citas.servicios.nombre = dr.GetValue(5).ToString();
                    citas.mascota.nombre = dr.GetValue(6).ToString();
                    citas.veterinario.nombre = dr.GetValue(7).ToString();


                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return citas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        //actualizar
        public bool actualizarcitas(EntidadCitas citas)
        {
            try
            {
                int i = 0;
                SqlCommand cmd = new SqlCommand("ups_actualizacitas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcitas", citas.idcitas);
                cmd.Parameters.AddWithValue("@fecha", citas.fechar);
                cmd.Parameters.AddWithValue("@hora", citas.hora);
                cmd.Parameters.AddWithValue("@estado", citas.estado);
                cmd.Parameters.AddWithValue("@idcliente", citas.cliente.idcliente);
                cmd.Parameters.AddWithValue("@idservicios", citas.servicios.idservicios);
                cmd.Parameters.AddWithValue("@idmascota", citas.mascota.idmascota);
                cmd.Parameters.AddWithValue("@idveterinario", citas.veterinario.idveterinario);

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
        public string borrarcitas(int id)
        {

            try
            {
                string resultado = "";
                SqlCommand cmd = new SqlCommand("usp_borrarcitas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcitas", id);
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