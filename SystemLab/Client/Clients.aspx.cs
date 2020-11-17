using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Controllers;
using SystemLab.Models;

namespace SystemLab.Client
{
    public partial class Clients : System.Web.UI.Page
    {

        private ClientsDatos clDatos = new ClientsDatos();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataClient();
            }
        }

        private void GetDataClient()
        {
            gDatos.DataSource = clDatos.getClients();
            gDatos.DataBind();            
        }

        private void GetOneClient(int id)
        {
            var data = clDatos.getClient(id);

            name.Text = data.Name;
            rnc.Text = data.RNC;
            address.Text = data.Address;
            emails.Text = data.Emails;
            contacts.Text = data.Contacts;

            hdClientID.Value = id.ToString();
        }       

        private void PostClient(Cliente cl)
        {
            int tipo;
            int.TryParse(hdTipo.Value, out tipo);

            clDatos.SaveClient(cl, tipo);
        }

        protected void new_Click(object sender, EventArgs e)
        {
            hdTipo.Value = "0";
            ControlClear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "modal", "modalShow()", true);            
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id;            

            if (e.CommandName == "editar")
            {
                int.TryParse(e.CommandArgument.ToString(), out Id);

                GetOneClient(Id);
            }

            if (e.CommandName == "delete")
            {
                int.TryParse(e.CommandArgument.ToString(), out Id);
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "modal", "modalShow()", true);

            hdTipo.Value = "1";
        }        

        protected void save_Click(object sender, EventArgs e)
        {
            int ClientID;
            int.TryParse(hdClientID.Value, out ClientID);


            try
            {
                Cliente cl = new Cliente();
                cl.ClientID = ClientID;
                cl.Name = name.Text;
                cl.RNC = rnc.Text;
                cl.Contacts = contacts.Text;
                cl.Address = address.Text;
                cl.Emails = emails.Text;

                PostClient(cl);

                GetDataClient();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        void ControlClear()
        {
            name.Text = string.Empty;
            rnc.Text = string.Empty;
            address.Text = string.Empty;
            emails.Text = string.Empty;
            contacts.Text = string.Empty;
        }
    }
}