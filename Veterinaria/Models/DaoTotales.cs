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
    public class DaoTotales
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<EntidadTotales> listar()
        {

            List<EntidadTotales> listado = new List<EntidadTotales>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_totales", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EntidadTotales totales = new EntidadTotales();
                    totales.cliente.idcliente = int.Parse(dr.GetValue(0).ToString());
                    totales.mascota.idmascota = int.Parse(dr.GetValue(1).ToString());
                    totales.servicio.idservicios = int.Parse(dr.GetValue(2).ToString());
                    totales.veterinario.idveterinario = int.Parse(dr.GetValue(3).ToString());
                    totales.cita.idcitas = int.Parse(dr.GetValue(4).ToString());
                    totales.historial.idhistorial = int.Parse(dr.GetValue(5).ToString());
                    totales.calendario.idcalendario = int.Parse(dr.GetValue(6).ToString());
                    totales.usuario.IdUsuario = int.Parse(dr.GetValue(7).ToString());

                    listado.Add(totales);
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
    }
}