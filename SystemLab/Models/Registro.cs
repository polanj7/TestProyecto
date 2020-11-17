using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class Registro
    {
        [Key]
        public int RegistroID { get; set; }
        
        public int ClientID { get; set; }

        [MaxLength(40)]
        public string NoRegistro { get; set; }

        [MaxLength(50)]
        public string Proyecto { get; set; }

        [MaxLength(15)]
        public string Volumen { get; set; }       

        public string Direccion { get; set; }

        public string FechaUltimoEmail { get; set; }

        public int CantidadEmailEnviados { get; set; }

        public string Contacto { get; set; }

        public string Elaboracion { get; set; }

        [ForeignKey("ClientID")]
        public virtual Cliente Cliente { get; set; }       
    }
}