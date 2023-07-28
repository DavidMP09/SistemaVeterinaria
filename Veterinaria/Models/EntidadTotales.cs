using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadTotales
    {
        public EntidadCliente cliente = new EntidadCliente();
        public EntidadMascota mascota = new EntidadMascota();
        public EntidadServicios servicio = new EntidadServicios();
        public EntidadVeterinario veterinario = new EntidadVeterinario();
        public EntidadCitas cita = new EntidadCitas();
        public EntidadHistorial historial = new EntidadHistorial();
        public EntidadCalendario calendario = new EntidadCalendario();
        public Usuario usuario = new Usuario();

        public EntidadTotales()
        {
        }

        public EntidadTotales(EntidadCliente cliente, EntidadMascota mascota, EntidadServicios servicio, EntidadVeterinario veterinario, EntidadCitas cita, EntidadHistorial historial, EntidadCalendario calendario, Usuario usuario)
        {
            this.cliente = cliente;
            this.mascota = mascota;
            this.servicio = servicio;
            this.veterinario = veterinario;
            this.cita = cita;
            this.historial = historial;
            this.calendario = calendario;
            this.usuario = usuario;
        }
    }
}