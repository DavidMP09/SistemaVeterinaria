using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Veterinaria.Models;
using System.Data;

namespace Veterinaria.Models
{
    public class DaoServicios
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<EntidadServicios> listar()
        {

            List<EntidadServicios> listado = new List<EntidadServicios>();

            try
            {

                SqlCommand cmd = new SqlCommand("usp_listarservicios", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    EntidadServicios servicios = new EntidadServicios();
                    servicios.idservicios = int.Parse(dr.GetValue(0).ToString());
                    servicios.nombre = dr.GetValue(1).ToString();
                    servicios.descripcion = dr.GetValue(2).ToString();
                   
                    listado.Add(servicios);
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
        public bool guardar(EntidadServicios servicios)
        {

                int id = 0;
                SqlCommand cmd = new SqlCommand("usp_insertarservicios", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", servicios.nombre);
                cmd.Parameters.AddWithValue("@descripcion", servicios.descripcion);
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
        public EntidadServicios buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarserviciosID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                EntidadServicios servicios = new EntidadServicios();
                while (dr.Read())
                {
                    servicios.idservicios = int.Parse(dr.GetValue(0).ToString());
                    servicios.nombre = dr.GetValue(1).ToString();
                    servicios.descripcion = dr.GetValue(2).ToString();
                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return servicios;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public bool actualizarservicios(EntidadServicios servicios)
        {
                int i = 0;

                SqlCommand cmd = new SqlCommand("ups_actualizaservicio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", servicios.nombre);
                cmd.Parameters.AddWithValue("@descripcion", servicios.descripcion);
                cmd.Parameters.AddWithValue("@idservicio", servicios.idservicios);
                conn.Open();
                i=cmd.ExecuteNonQuery();
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
        public string borrarservicio(int id)
        {

            string resultado = "";
            SqlCommand cmd = new SqlCommand("usp_borrarservicios", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idservicios", id);
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