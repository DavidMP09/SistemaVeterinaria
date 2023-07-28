using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadMascota
    {
        public int idmascota { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string pesoPromedio { get; set; }
        public string pesoActual { get; set; }
        public string fechaNacimiento { get; set; }
        public EntidadCliente cliente =  new EntidadCliente();
        public EntidadHistorial historial = new EntidadHistorial();
        public EntidadCalendario calendario = new EntidadCalendario();

        public EntidadMascota()
        {
        }

        public EntidadMascota(int idmascota, string nombre, string descripcion, string pesoPromedio, string pesoActual, string fechaNacimiento, EntidadCliente cliente, EntidadHistorial historial, EntidadCalendario calendario)
        {
            this.idmascota = idmascota;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.pesoPromedio = pesoPromedio;
            this.pesoActual = pesoActual;
            this.fechaNacimiento = fechaNacimiento;
            this.cliente = cliente;
            this.historial = historial;
            this.calendario = calendario;
        }
    }
}