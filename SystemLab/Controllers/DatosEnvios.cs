using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemLab.Models;

namespace SystemLab.Controllers
{

    public class EnsayosList
    {
        public int Id { get; set; }
        public string registro { get; set; }
        public string proyecto { get; set; }
        public string cliente { get; set; }

        public int ClientID { get; set; }
        public string FUEmasCG { get; set; }//---Fecha del ultimo correo mas Conteo de email
    }

    public class EnsayosDetalleList
    {
        public int Id { get; set; }
        public string subregistro { get; set; }
        public string resistencia { get; set; }
        public string elemento { get; set; }
        public string sector { get; set; }
        public DateTime vaciado { get; set; }
    }

    public class EnsayosEdadDetalleList
    {
        public int Id { get; set; }
        public string dias { get; set; }
        public string probetas { get; set; }
        public string dimension { get; set; }
        public string conduce { get; set; }
        public decimal carga { get; set; }
    }

    public class DatosEnvios
    {

        private ApplicationDbContext ctx = new ApplicationDbContext();


        public List<EnsayosList> RegistroLists(int ClienteID, string Registro, string Proyecto)
        {
            var data = (from a in ctx.Ensayos
                        where (ClienteID == 0 || a.Edad.RegistroDetalle.Registro.ClientID == ClienteID)
                              && (Proyecto == "-" || a.Edad.RegistroDetalle.Registro.Proyecto == Proyecto.Trim())
                              && (Registro == "" || a.Edad.RegistroDetalle.Registro.NoRegistro == Registro.Trim())                              
                        select new EnsayosList
                        {
                            Id = a.Edad.RegistroDetalle.RegistroID,
                            registro = a.Edad.RegistroDetalle.Registro.NoRegistro,
                            proyecto = a.Edad.RegistroDetalle.Registro.Proyecto,
                            cliente = a.Edad.RegistroDetalle.Registro.Cliente.Name,
                            ClientID = a.Edad.RegistroDetalle.Registro.ClientID,
                            FUEmasCG = a.Edad.RegistroDetalle.Registro.FechaUltimoEmail  + " - " + a.Edad.RegistroDetalle.Registro.CantidadEmailEnviados
                        }).Distinct().AsQueryable();

            return data.ToList();
        }

        public List<EnsayosDetalleList> RegistroDetalleLists(int Id)
        {
            var data = (from a in ctx.EnsayoDetalles
                        where a.Ensayo.Edad.RegistroDetalle.RegistroID == Id
                        select new EnsayosDetalleList
                        {
                            Id = a.Ensayo.Edad.RegistroDetalle.ID,
                            subregistro = a.Ensayo.Edad.RegistroDetalle.SubRegistro,
                            resistencia = a.Ensayo.Edad.RegistroDetalle.Resistencia.ToString(),
                            elemento = a.Ensayo.Edad.RegistroDetalle.Elemento,
                            sector = a.Ensayo.Edad.RegistroDetalle.Sector,
                            vaciado = a.Ensayo.Edad.RegistroDetalle.FechaVaciado
                        }).Distinct().ToList();

            return data;
        }

        public List<EnsayosEdadDetalleList> RegistroDetalleEdadLists(int Id)
        {

            var data = (from a in ctx.EnsayoDetalles
                        where a.Ensayo.Edad.SubRegistroID == Id
                        group a by a.EnsayoID into Gr
                        select new EnsayosEdadDetalleList
                        {
                            Id = Gr.Max(b=> b.Ensayo.Edad.ID),
                            dias = Gr.Max(b => b.Ensayo.Edad.Dias.ToString()),
                            probetas = Gr.Max(b => b.Ensayo.Edad.CantidadProbetas.ToString()),
                            dimension = Gr.Max(b => b.Ensayo.Edad.Dimension),
                            conduce = Gr.Max(b => b.Ensayo.Edad.Conduce),
                            carga = Gr.Average(b => b.Carga)

                        }).ToList();

            return data;
        }






    }
}