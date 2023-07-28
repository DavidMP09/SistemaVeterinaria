using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadVeterinario
    {
        public int idveterinario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }

        public EntidadVeterinario()
        {
        }

        public EntidadVeterinario(int idveterinario, string nombre, string apellido, string especialidad, string telefono, string correo)
        {
            this.idveterinario = idveterinario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.especialidad = especialidad;
            this.telefono = telefono;
            this.correo = correo;
        }
    }
}