using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Veterinaria.Models;

namespace Veterinaria.Models
{
    public class DaoUsuario
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<Usuario> listar()
        {

            List<Usuario> listado = new List<Usuario>();

            try
            {

                SqlCommand cmd = new SqlCommand("usp_listarusuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = int.Parse(dr.GetValue(0).ToString());
                    usuario.Correo = dr.GetValue(1).ToString();
                    usuario.Clave = dr.GetValue(2).ToString();
                    listado.Add(usuario);
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
        public Usuario buscarID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_buscarusuarioID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Usuario usuario = new Usuario();
                while (dr.Read())
                {
                    usuario.IdUsuario = int.Parse(dr.GetValue(0).ToString());
                    usuario.Correo = dr.GetValue(1).ToString();
                    usuario.Clave = dr.GetValue(2).ToString();
                }
                conn.Close();
                dr.Close();
                cmd.Dispose();

                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        //actualizar
        public bool actualizarusuario(Usuario usuario)
        {
            try
            {
                int i = 0;
                SqlCommand cmd = new SqlCommand("ups_actualizausuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@idusuario", usuario.IdUsuario);
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
        public string borrarusuario(int id)
        {

            try
            {
                string resultado = "";
                SqlCommand cmd = new SqlCommand("usp_borrarusuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", id);
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