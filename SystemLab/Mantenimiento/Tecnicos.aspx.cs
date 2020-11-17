using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Models;

namespace SystemLab.Mantenimiento
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        static int RespID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void btnAddT_Click(object sender, EventArgs e)
        {
            if (txtTecn.Text == string.Empty)
            {
                lblMesnajeDanger.Text = "Coloque el nombre del tecnico";
                return;
            }

            try
            {
                if (RespID == 0)
                {
                    //---New
                    ctx.Responsables.Add(new  Responsables{ Nombre= txtTecn.Text.Trim()});                    

                }
                else
                {
                    var u = ctx.Responsables.Find(RespID);
                    u.Nombre = txtTecn.Text.Trim();
                    //---Update
                }

                ctx.SaveChanges();
                CargarGrid();
                RespID = 0;

                txtTecn.Text = string.Empty;
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void grvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {           

            if (e.CommandName == "editar")
            {                
                int.TryParse(e.CommandArgument.ToString(), out RespID);

                var d = ctx.Responsables.Find(RespID);
                txtTecn.Text = d.Nombre;      
                
            }

            if (e.CommandName == "delete")
            {
                int.TryParse(e.CommandArgument.ToString(), out RespID);

                var r = ctx.Responsables.Find(RespID);
                if (r != null)
                {
                    ctx.Responsables.Remove(r);
                    ctx.SaveChanges();
                }
            }
        }

        private void CargarGrid()
        {
            var data = ctx.Responsables.ToList();

            grvDatos.DataSource = data;
            grvDatos.DataBind();
        }

    }
}