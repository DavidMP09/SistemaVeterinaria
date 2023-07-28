using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }


        public string ConfirmarClave { get; set; }

        public Usuario()
        {
        }

        public Usuario(int idUsuario, string correo, string clave, string confirmarClave)
        {
            IdUsuario = idUsuario;
            Correo = correo;
            Clave = clave;
            ConfirmarClave = confirmarClave;
        }
    }
}