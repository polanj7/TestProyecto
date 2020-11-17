using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{  
    public class Cliente
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string RNC { get; set; }

        [MaxLength(150)]
        public string Emails { get; set; }

        [MaxLength(50)]
        public string Contacts { get; set; }

        public string Address { get; set; }
     }
}