using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class EntidadCitas
    {
        public int idcitas { get; set; }
        public string fechar { get; set; }
        public string hora { get; set; }
        public string estado { get; set; }

        public EntidadCliente cliente = new EntidadCliente();
        public EntidadServicios servicios = new EntidadServicios();
        public EntidadMascota mascota = new EntidadMascota();
        public EntidadVeterinario veterinario = new EntidadVeterinario();

        public EntidadCitas()
        {
        }

        public EntidadCitas(int idcitas, string fechar, string hora, string estado, EntidadCliente cliente, EntidadServicios servicios, EntidadMascota mascota, EntidadVeterinario veterinario)
        {
            this.idcitas = idcitas;
            this.fechar = fechar;
            this.hora = hora;
            this.estado = estado;
            this.cliente = cliente;
            this.servicios = servicios;
            this.mascota = mascota;
            this.veterinario = veterinario;
        }
    }
}