using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class Documentos
    {
        /*Puede cambiar en el futuro*/
        public int DocumentosID { get; set; }

        public int ProyectoID { get; set; }

        public byte[] DocXHash { get; set; }

        public string PathDocX { get; set; }

        public string Nombre { get; set; }

        public string Ext { get; set; }

        [ForeignKey("ProyectoID")]
        public virtual Registro Proyecto { get; set; }
    }
}