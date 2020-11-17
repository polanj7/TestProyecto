using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemLab.Models;

namespace SystemLab.Controllers
{
    public class RegistroDatos
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        //Lista de registros
        public List<Registro> GetRegistros()
        {
            return ctx.Registros.ToList();
        }

        public List<RegistroDetalle> GetRegistrosDetalle(string reg)
        {
            if (reg == string.Empty)
            {
                return null;
            }

            var data = ctx.RegistroDetalles.Where(p => p.Registro.NoRegistro == reg).ToList();
            return data;
        }

        //Un registro
        public Registro GetRegistro(string reg)
        {
            if (reg == string.Empty)
            {
                return null;
            }

            var data = ctx.Registros.Where(p => p.NoRegistro == reg).FirstOrDefault();

            return data;
        }    
        
        //Envios de data
        public Registro SaveRegistros(Registro reg)
        {
            if (reg != null)
            {
                if (reg.RegistroID == 0)
                {
                    //----New
                    ctx.Registros.Add(reg);
                }

                if (reg.RegistroID != 0)
                {
                    //----Update
                    ctx.Entry(reg).State = EntityState.Modified;
                }
            }

            if (ctx.SaveChanges() > 0)
            {
                return reg;
            }

            return null;
        }

    }
}