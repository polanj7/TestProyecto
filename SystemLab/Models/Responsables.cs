using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class Responsables
    {
        [Key]
        public int ResponsablesID { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}