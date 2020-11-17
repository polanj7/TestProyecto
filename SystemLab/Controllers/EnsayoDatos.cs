using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemLab.Models;

namespace SystemLab.Controllers
{
    public class EnsayoDatos
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        public Ensayo SaveEnsayo(Ensayo ensayo)
        {
            if (ensayo != null)
            {
                if (ensayo.EnsayoID == 0)
                {
                    //----New
                    ctx.Ensayos.Add(ensayo);
                }
                else
                {
                    //----Update
                    ctx.Entry(ensayo).State = EntityState.Modified;
                }
            }

            if (ctx.SaveChanges() > 0)
            {
                return ensayo;
            }

            return null;
        }

        public void SaveDetalleEnsayo(EnsayoDetalle ensayoDetalle)
        {
            if (ensayoDetalle != null)
            {
                if (ensayoDetalle.EnsayoDetalleID == 0)
                {
                    //----New
                    ctx.Entry(ensayoDetalle).State = EntityState.Added;
                }

                if (ensayoDetalle.EnsayoDetalleID != 0)
                {
                    //----Update
                    ctx.Entry(ensayoDetalle).State = EntityState.Modified;
                }
            }

            ctx.SaveChanges();
            
        }

        public EnsayoDetalle SaveEnsayoDetalle(EnsayoDetalle ensDetalle)
        {
            if (ensDetalle != null)
            {
                if (ensDetalle.EnsayoDetalleID == 0)
                {
                    //----New
                    ctx.EnsayoDetalles.Add(ensDetalle);
                }

                if (ensDetalle.EnsayoDetalleID != 0)
                {
                    //----Update
                    ctx.Entry(ensDetalle).State = EntityState.Modified;
                }
            }

            if (ctx.SaveChanges() > 0)
            {
                return ensDetalle;
            }

            return null;
        }

    }
}