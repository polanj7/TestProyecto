using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemLab.Models;

namespace SystemLab.Controllers
{

    public class EnsayoDTO
    {
        public int Id { get; set; }

        public string Registro { get; set; }

        public string Elemento { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        public string Dias { get; set; }

        public string EdadActual { get; set; }
            
        public string Probetas { get; set; }

        public int CantidadProbetas { get; set; }

        public string FechaString { get { return Fecha.ToString("dd/MM/yyyy"); } }
    }

    public class ResultadoEnsayo
    {

        private ApplicationDbContext ctx = new ApplicationDbContext();

        public List<EnsayoDTO> EnsayoList(DateTime f, string Registro = "")
        {

            List<EnsayoDTO> data = new List<EnsayoDTO>();
    
            DateTime date;

            if (f.Year < 2000)
            {
                date = DateTime.Now;
            }
            else
            {
                date = f;
            }

            /*3,7,14,28 dias*/

            var fechaActual = DateTime.Now.Date;

            data = (from x in ctx.Edads
                        where Registro == string.Empty ? 
                        (DbFunctions.DiffDays(x.RegistroDetalle.FechaVaciado, date) == x.Dias) : 
                        x.RegistroDetalle.Registro.NoRegistro == Registro
                        select new EnsayoDTO
                        {
                            Id = x.ID,
                            Registro = x.RegistroDetalle.SubRegistro,
                            Elemento = x.RegistroDetalle.Elemento,
                            Fecha = (x.RegistroDetalle.FechaVaciado),
                            Dias = x.Dias.ToString(),
                            EdadActual = (DbFunctions.DiffDays(x.RegistroDetalle.FechaVaciado, fechaActual)).ToString(),
                            Probetas = x.CantidadProbetas + " de " + x.Dimension,
                            CantidadProbetas = x.CantidadProbetas
                        }).ToList();            

            return data;

        }


    }
}