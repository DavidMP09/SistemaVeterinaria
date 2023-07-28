using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Veterinaria.Models
{
    public class DaoCliente
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<EntidadCliente> listar()
        {

            List<EntidadCliente> listado = new List<EntidadCliente>();

            try
            {

                SqlCommand cmd = new SqlCommand("usp_listarcliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    EntidadCliente cliente = new EntidadCliente();
                    cliente.idcliente = int.Parse(dr.GetValue(0).ToString());
                    cliente.nombre = dr.GetValue(1).ToString();
                    cliente.apellido = dr.GetValue(2).ToString();
                    cliente.telefono = dr.GetValue(3).ToString();
                    cliente.correo = dr.GetValue(4).ToString();
                    cliente.dni = dr.GetValue(5).ToString();
                    cliente.direccion = dr.GetValue(6).ToString();
                    listado.Add(cliente);
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
        public bool guardar(EntidadCliente cliente)
        {
            int id = 0;
            SqlCommand cmd = new SqlCommand("usp_insertarcliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.apellido);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@correo", cliente.correo);
                cmd.Parameters.AddWithValue("@dni", cliente.dni);
                cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
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
        public EntidadCliente buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarclienteID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                EntidadCliente cliente = new EntidadCliente();
                while (dr.Read())
                {
                    cliente.idcliente = int.Parse(dr.GetValue(0).ToString());
                    cliente.nombre = dr.GetValue(1).ToString();
                    cliente.apellido = dr.GetValue(2).ToString();
                    cliente.telefono = dr.GetValue(3).ToString();
                    cliente.correo = dr.GetValue(4).ToString();
                    cliente.dni = dr.GetValue(5).ToString();
                    cliente.direccion = dr.GetValue(6).ToString();

                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public bool actualizarcliente(EntidadCliente cliente)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("ups_actualizacliente", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.apellido);
            cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
            cmd.Parameters.AddWithValue("@correo", cliente.correo);
            cmd.Parameters.AddWithValue("@dni", cliente.dni);
            cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
            cmd.Parameters.AddWithValue("@idcliente", cliente.idcliente);
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
        public string borrarcliente(int id)
        {

            string resultado = "";
            SqlCommand cmd = new SqlCommand("usp_borrarcliente", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcliente", id);
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