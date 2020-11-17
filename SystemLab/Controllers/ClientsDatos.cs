using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemLab.Models;

namespace SystemLab.Controllers
{
    public class ClientsDatos
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        public List<Cliente> getClients()
        {
            var t = ctx.Clients.ToList(); 
            return t;
        }

        public Cliente getClient(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var t = ctx.Clients.Find(id);
            return t;
        }


        public void SaveClient(Cliente cl, int tipo)
        {
            /*0=new, 1=update*/

            if (cl == null)
            {
                return;
            }

            if (tipo == 0)
            {
                //---New register
                ctx.Clients.Add(cl);                
            }

            if (tipo == 1)
            {
                //----Update register
                ctx.Entry(cl).State = EntityState.Modified;
            }

            ctx.SaveChanges();
        }

    }
}