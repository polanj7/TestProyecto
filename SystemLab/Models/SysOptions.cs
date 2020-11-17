using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    public class SysOptions
    {
        [Key]
        public int SysOptionsID { get; set; }
        
        public string Descripcion { get; set; }

        [Required]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}