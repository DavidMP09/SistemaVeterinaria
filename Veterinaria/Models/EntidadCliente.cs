using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadCliente
    {
        public int idcliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }

        public EntidadCliente()
        {
        }

        public EntidadCliente(int idcliente, string nombre, string apellido, string telefono, string correo, string dni, string direccion)
        {
            this.idcliente = idcliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.correo = correo;
            this.dni = dni;
            this.direccion = direccion;
        }
    }
}