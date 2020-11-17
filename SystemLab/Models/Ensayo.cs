using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class Ensayo
    {
        [Key]
        public int EnsayoID { get; set; }

        public int EdadID { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string UsuarioID { get; set; }

        [ForeignKey("EdadID")]
        public virtual Edad Edad { get; set; }

        [ForeignKey("UsuarioID")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}