using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadCalendario
    {
        public int idcalendario { get; set; }
        public string fecha { get; set; }
        public string enfermedad { get; set; }

        public EntidadCalendario()
        {
        }

        public EntidadCalendario(int idcalendario, string fecha, string enfermedad)
        {
            this.idcalendario = idcalendario;
            this.fecha = fecha;
            this.enfermedad = enfermedad;
        }
    }
}