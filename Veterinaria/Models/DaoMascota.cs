using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Veterinaria.Models
{
    public class DaoMascota
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<EntidadMascota> listar()
        {

            List<EntidadMascota> listado = new List<EntidadMascota>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_listarmascota", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EntidadMascota mascota = new EntidadMascota();
                    mascota.idmascota = int.Parse(dr.GetValue(0).ToString());
                    mascota.nombre = dr.GetValue(1).ToString();
                    mascota.descripcion = dr.GetValue(2).ToString();
                    mascota.pesoPromedio = dr.GetValue(3).ToString();
                    mascota.pesoActual = dr.GetValue(4).ToString();
                    mascota.fechaNacimiento = dr.GetValue(5).ToString();
                    mascota.cliente.nombre = dr.GetValue(6).ToString();
                    mascota.historial.fecha = dr.GetValue(7).ToString();
                    mascota.calendario.fecha = dr.GetValue(8).ToString();
                    listado.Add(mascota);
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
        public bool guardar(EntidadMascota mascota)
        {

            try
            {
                int id = 0;
                SqlCommand cmd = new SqlCommand("usp_insertarmascota", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@descripcion", mascota.descripcion);
                cmd.Parameters.AddWithValue("@pesoPromedio", mascota.pesoPromedio);
                cmd.Parameters.AddWithValue("@pesoActual", mascota.pesoActual);
                cmd.Parameters.AddWithValue("@fechaNacimiento", mascota.fechaNacimiento);
                cmd.Parameters.AddWithValue("@idcliente", mascota.cliente.idcliente);
                cmd.Parameters.AddWithValue("@idhistorial", mascota.historial.idhistorial);
                cmd.Parameters.AddWithValue("@idcalendario", mascota.calendario.idcalendario);
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }
        public EntidadMascota buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarmascotaID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                EntidadMascota mascota = new EntidadMascota();
                while (dr.Read())
                {
                    mascota.idmascota = int.Parse(dr.GetValue(0).ToString());
                    mascota.nombre = dr.GetValue(1).ToString();
                    mascota.descripcion = dr.GetValue(2).ToString();
                    mascota.pesoPromedio = dr.GetValue(3).ToString();
                    mascota.pesoActual = dr.GetValue(4).ToString();
                    mascota.fechaNacimiento = dr.GetValue(5).ToString();
                    mascota.cliente.nombre = dr.GetValue(6).ToString();
                    mascota.historial.fecha = dr.GetValue(7).ToString();
                    mascota.calendario.fecha = dr.GetValue(8).ToString();
                    
                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return mascota;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        //actualizar
        public bool actualizarmascota(EntidadMascota mascota)
        {
            try
            {
                int i = 0;
                SqlCommand cmd = new SqlCommand("ups_actualizamascota", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmascota", mascota.idmascota);
                cmd.Parameters.AddWithValue("@nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@descripcion", mascota.descripcion);
                cmd.Parameters.AddWithValue("@pesoPromedio", mascota.pesoPromedio);
                cmd.Parameters.AddWithValue("@pesoActual", mascota.pesoActual);
                cmd.Parameters.AddWithValue("@fechaNacimiento", mascota.fechaNacimiento);
                cmd.Parameters.AddWithValue("@idcliente", mascota.cliente.idcliente);
                cmd.Parameters.AddWithValue("@idhistorial", mascota.historial.idhistorial);
                cmd.Parameters.AddWithValue("@idcalendario", mascota.calendario.idcalendario);
                
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
        public string borrarmascota(int id)
        {

            try
            {
                string resultado = "";
                SqlCommand cmd = new SqlCommand("usp_borrarmascota", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmascota", id);
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