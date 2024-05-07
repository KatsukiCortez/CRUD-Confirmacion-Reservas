using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backend.Models
{
    public class Tours
    {
        [Key]
        public int id_tour { get; set; }

        [Required]
        [StringLength(255)]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal precio { get; set; }
    }
}