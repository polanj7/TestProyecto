using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemLab.Models;

namespace SystemLab.Controllers
{
    public class RegistroDetalleDatos
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        //Lista de registros
        public List<RegistroDetalle> GetRegistros()
        {
            return ctx.RegistroDetalles.ToList();
        }

        //Un registro
        public RegistroDetalle GetSubRegistro(string reg)
        {
            if (reg == string.Empty)
            {
                return null;
            }

            var data = ctx.RegistroDetalles.Where(p => p.SubRegistro == reg).FirstOrDefault();

            return data;
        }

        /*Busca desde la BD*/
        public List<Edad> EdadList(string reg)
        {
            if (reg == string.Empty)
            {
                return null;
            }

            var data = ctx.Edads.Where(p => p.RegistroDetalle.SubRegistro == reg).ToList();

            return data;

        }

        public RegistroDetalle SaveRegistros(RegistroDetalle reg)
        {
            /*Valida el mmg que estra introducconedo la data*/
            var val = ctx.RegistroDetalles.Where(p => p.SubRegistro == reg.SubRegistro);
                              

            if (reg != null)
            {
                if (val.Count() == 0)
                {
                    //----New
                    ctx.RegistroDetalles.Add(reg);
                }
                else
                {
                    //----Update
                    val.FirstOrDefault().Agregado = reg.Agregado;
                    val.FirstOrDefault().Curado = reg.Curado;
                    //val.FirstOrDefault().Elaboracion = reg.Elaboracion;
                    val.FirstOrDefault().Elemento = reg.Elemento;
                    val.FirstOrDefault().FechaEntrega = reg.FechaEntrega;
                    val.FirstOrDefault().FechaVaciado = reg.FechaVaciado;
                    val.FirstOrDefault().HoraFinal = reg.HoraFinal;
                    val.FirstOrDefault().HoraInicial = reg.HoraInicial;
                    val.FirstOrDefault().Hormigonera = reg.Hormigonera;
                    val.FirstOrDefault().RegistroID = reg.RegistroID;
                    val.FirstOrDefault().Resistencia = reg.Resistencia;
                    val.FirstOrDefault().Sector = reg.Sector;
                    val.FirstOrDefault().Slump = reg.Slump;
                    val.FirstOrDefault().SubRegistro = reg.SubRegistro;
                    val.FirstOrDefault().Temp = reg.Temp;
                    val.FirstOrDefault().TotalProbetas = reg.TotalProbetas;
                    val.FirstOrDefault().Conduce = reg.Conduce;
                }
            }

            if (ctx.SaveChanges() > 0)
            {
                return reg;
            }

            return null;
        }

        public void DeleteRegistro(string SubReg)
        {
            if (SubReg == string.Empty)
            {
                return;
            }
            //Jose - Validar que solo exista un solo subRegistro en la base de taos completa
            var dataDelete = ctx.RegistroDetalles.Where(p => p.SubRegistro == SubReg);
            if (dataDelete.Count() > 0)
            {
                ctx.RegistroDetalles.Remove(dataDelete.FirstOrDefault());
                ctx.SaveChanges();
            }
        }

    }
}