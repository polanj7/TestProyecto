using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class Edad
    {
        [Key]
        public int ID { get; set; }
        
        public int SubRegistroID { get; set; }

        public int Dias { get; set; }

        public int CantidadProbetas { get; set; }

        [MaxLength(30)]
        public string Dimension { get; set; } //Un desplegable con 10x20cm y 15x30cm

        [MaxLength(30)]
        public string Conduce { get; set; }

        [ForeignKey("SubRegistroID")]
        public virtual RegistroDetalle RegistroDetalle { get; set; }

    }
}