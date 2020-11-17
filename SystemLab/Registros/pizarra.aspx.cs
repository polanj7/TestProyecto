using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Controllers;
using SystemLab.Models;

namespace SystemLab.Registros
{
    public partial class pizarra : System.Web.UI.Page
    {
        private ResultadoEnsayo rResultadoEnsayo = new ResultadoEnsayo();
        private EnsayoDatos ensayoDatos = new EnsayoDatos();
        private ApplicationDbContext ctx = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }


        private void GetData()
        {
            try
            {

                DateTime fecha;
                DateTime.TryParse(filtroDate.Text.Trim(), out fecha);

                var data = rResultadoEnsayo.EnsayoList(fecha);

                grvDatos.DataSource = data;
                grvDatos.DataBind();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            
            GetData();
            
        }
       
        protected void grvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblID = (Label)e.Row.FindControl("lblID");

                int ID;
                int.TryParse(lblID.Text, out ID);


                //var a = ctx.EnsayoDetalles.Where(p => p.Ensayo.EdadID == ID);

            }
        }
    }
}