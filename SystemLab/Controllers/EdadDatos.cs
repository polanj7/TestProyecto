using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemLab.Models;

namespace SystemLab.Controllers
{

    public class EdadDTO
    {
        public int ID { get; set; }

        public int Dias { get; set; }

        public int TotalProbetas { get; set; }

        public int CantidadProbetas { get; set; }
        
        public string Dimension { get; set; }

        public string Conduce { get; set; }

        public bool Nueva { get; set; }
    }

    public class EdadDatos
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private static List<EdadDTO> EdadList = new List<EdadDTO>();



    }
}