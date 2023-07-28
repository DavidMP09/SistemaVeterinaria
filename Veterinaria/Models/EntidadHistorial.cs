using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadHistorial
    {
        public int idhistorial  { get; set; }
        public string fecha { get; set; }
        public string tratamientos { get; set; }
        public string enfermedad { get; set; }
        public string evulucion { get; set; }

        public EntidadHistorial()
        {
        }

        public EntidadHistorial(int idhistorial, string fecha, string tratamientos, string enfermedad, string evulucion)
        {
            this.idhistorial = idhistorial;
            this.fecha = fecha;
            this.tratamientos = tratamientos;
            this.enfermedad = enfermedad;
            this.evulucion = evulucion;
        }
    }
}