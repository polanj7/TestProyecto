using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class EnsayoDetalle
    {
        [Key]
        public int EnsayoDetalleID { get; set; }

        public int EnsayoID { get; set; }

        public decimal Peso { get; set; }

        public decimal Carga { get; set; }

        public decimal Falla { get; set; }

        [ForeignKey("EnsayoID")]
        public virtual Ensayo Ensayo { get; set; }

    }
}