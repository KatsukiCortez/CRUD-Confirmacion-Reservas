using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models;

namespace backend.Models
{
    public class Pagos
    {
        [Key]
        public int id_pago { get; set; }

        public int id_reserva { get; set; }

        [ForeignKey("id_reserva")]
        public Reservas reserva { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal monto { get; set; }

        public DateTime fecha_pago { get; set; }
    }
}