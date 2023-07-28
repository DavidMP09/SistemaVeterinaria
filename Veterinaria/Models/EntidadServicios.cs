using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadServicios
    {
        public int idservicios { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public EntidadServicios()
        {
        }

        public EntidadServicios(int idservicios, string nombre, string descripcion)
        {
            this.idservicios = idservicios;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

    }
}