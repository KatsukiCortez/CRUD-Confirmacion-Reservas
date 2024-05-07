using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models;

namespace backend.Models
{
    public class Reservas
    {
        [Key]
        public int id_reserva { get; set; }

        public int id_tour { get; set; }

        [ForeignKey("IdTour")]
        public Tours tour { get; set; }

        [StringLength(12)]
        public string cliente { get; set; }

        [ForeignKey("IdCliente")]
        public Clientes Cliente { get; set; }

        public DateTime FechaReserva { get; set; }

        public int CantidadPersonas { get; set; }
    }
}