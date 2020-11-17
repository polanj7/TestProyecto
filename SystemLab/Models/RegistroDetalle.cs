using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class RegistroDetalle
    {
        [Key]
        public int ID { get; set; }

        public int RegistroID { get; set; }

        public string SubRegistro { get; set; }

        public string HoraInicial { get; set; }

        public string HoraFinal { get; set; }

        public decimal Resistencia { get; set; } //Unidad de medidad kg/cm2

        public decimal Slump { get; set; } //Va en pulgada--- colocar en el placeholder

        public decimal Temp { get; set; } //C_o

        public string Elemento { get; set; }

        public string Sector { get; set; }

        //public string Elaboracion { get; set; } // LLeva dos opciones ej: Carlos - Indecal o Cliente

        public string Curado { get; set; }

        public string Agregado { get; set; } //Es un desplegable... se llama Tamaño max. agragado // Mortero-3/8"-1/2"-3/4"-1"-1 1/2"

        public DateTime FechaEntrega { get; set; } //La fecha de entrada al laboratorio

        public DateTime FechaVaciado { get; set; } //La fecha de entrada al laboratorio

        [MaxLength(50)]
        public string Hormigonera { get; set; }

        public decimal TotalProbetas { get; set; }

        [MaxLength(50)]
        public string Conduce { get; set; }

        [ForeignKey("RegistroID")]
        public virtual Registro Registro { get; set; }

    }
}