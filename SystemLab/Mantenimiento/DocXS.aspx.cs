using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Controllers;
using SystemLab.Models;

namespace SystemLab.Mantenimiento
{
    public partial class DocXS : System.Web.UI.Page
    {
        private DatosEnvios rDatos = new DatosEnvios();
        private ApplicationDbContext ctx = new ApplicationDbContext();
        ClientsDatos clients = new ClientsDatos();

        class DocXs
        {
            public string rutaMMG { get; set; }
        }
        class Proyec
        {
            public string Id { get; set; }
            public string Proyecto { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["verFileRegistroID"] != null)
                {
                    string[] NoRegiID = Session["verFileRegistroID"].ToString().Split('#');

                    txtRegistro.Text = NoRegiID[0].ToString();

                    if (CargarDocXs(Convert.ToInt16(NoRegiID[1])))
                        ScriptManager.RegisterStartupScript(this, GetType(), "modal", "modalShow()", true);
                }                     

                LlenaCliente();
                LlenaProyecto();
                CargaGrid();

                Session["verFileRegistroID"] = null;
            }
        }

        private void CargaGrid()
        {
            int.TryParse(cboCliente.SelectedValue, out int ClienteID);
            string Proyecto = cboProyecto.SelectedItem.Text;
            string Registro = txtRegistro.Text;


            var data = rDatos.RegistroLists(ClienteID, Registro, Proyecto);                        

            grvDatos.DataSource = data;
            grvDatos.DataBind();

        }


        private bool CargarDocXs(int id)
        {
            List<DocXs> lista = new List<DocXs>();

            var data = (from i in ctx.Documentos
                        where i.ProyectoID == id
                        select new { rutaMMG = i.DocXHash }).ToList();

            foreach (var a in data)
            {
                byte[] imgData = (byte[])a.rutaMMG;
                string strBase64 = Convert.ToBase64String(imgData);

                var s = "data:Image/jpg;base64," + strBase64;

                lista.Add(new DocXs { rutaMMG = s });
            }

            if (lista.Count() == 0)
            {
                return false;
            }

            dlData.DataSource = lista;
            dlData.DataBind();

            return true;
            
        }

        private void LlenaCliente()
        {
            var dataCl = clients.getClients();

            dataCl.Insert(0, new Cliente { ClientID = 0, Name = "-" });
            cboCliente.DataSource = dataCl;

            cboCliente.DataTextField = "Name";
            cboCliente.DataValueField = "ClientID";
            cboCliente.DataBind();
        }

        private void LlenaProyecto()
        {
            var dataCl = (from o in ctx.Registros
                          select new Proyec { Id = o.Proyecto, Proyecto = o.Proyecto }).ToList();

            dataCl.Insert(0, new Proyec { Id = "0", Proyecto = "-" });
            cboProyecto.DataSource = dataCl;
            cboProyecto.DataTextField = "Proyecto";
            cboProyecto.DataValueField = "Id";
            cboProyecto.DataBind();
        }

        protected void verFile_Click(object sender, EventArgs e)
        {
            LinkButton btnAprbar = (LinkButton)sender;
            GridViewRow rowId = (GridViewRow)btnAprbar.Parent.Parent;

            Label lblId = (Label)rowId.Cells[1].FindControl("lblId");
            int RegistroID;
            int.TryParse(lblId.Text, out RegistroID);

            if(CargarDocXs(RegistroID))
                 ScriptManager.RegisterStartupScript(this, GetType(), "modal", "modalShow()", true);
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
              CargaGrid();           
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registros/EnviosEnsayos.aspx");
        }
    }
}