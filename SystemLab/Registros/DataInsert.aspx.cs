using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Controllers;
using SystemLab.Dto;
using SystemLab.Models;
using SystemLab.Utilidades;

namespace SystemLab.Registros
{
    public partial class DataInsert : System.Web.UI.Page
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

                var data = rResultadoEnsayo.EnsayoList(fecha, txtRegistro.Text.Trim());

                grvDatos.DataSource = data;
                grvDatos.DataBind();

                if (data.Count() == 0)
                {
                    grabar.Visible = false;
                }
                else
                {
                    grabar.Visible = true;
                }


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void grvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEdad = (Label)e.Row.FindControl("lblID");
                Label lblProbetas = (Label)e.Row.FindControl("lblProbetas");

                int.TryParse(lblEdad.Text, out int EdadID);
                int.TryParse(lblProbetas.Text, out int cantidadProbetas);

                var data = ctx.EnsayoDetalles.Where(p => p.Ensayo.EdadID == EdadID).ToList();

                var j = data.Count();
                if (data.Count() > 0)
                {
                    /**/
                  

                    Label lblEnsayo= (Label)e.Row.FindControl("lblEnsayo");
                    lblEnsayo.Text = data.FirstOrDefault().EnsayoID.ToString();
                    /**/

                    int i = 0;                    

                    foreach (var a in data)
                    {      
                        i++;

                        Label lblEnsayoDetalle = (Label)e.Row.FindControl("lblEnsayoDetalle" + i);
                        lblEnsayoDetalle.Text = a.EnsayoDetalleID.ToString();

                        TextBox peso_ = (TextBox)e.Row.FindControl("peso" + i);
                        TextBox carga_ = (TextBox)e.Row.FindControl("carga" + i);
                        TextBox falla_ = (TextBox)e.Row.FindControl("falla" + i);


                        peso_.Text = a.Peso.ToString();
                        carga_.Text = a.Carga.ToString();
                        falla_.Text = a.Falla.ToString();  
                    }
                }

                for (int i = 1; cantidadProbetas >= i; i++)
                {
                    if (i > 3)
                    {
                        /*Crear nuevo objetos*/
                        //TextBox peso_ = new TextBox(); //(TextBox)e.Row.FindControl("peso" + i);
                        //peso_.ID = "peso"+i;

                        //peso_.Text = "44";
                        //TextBox carga_ = (TextBox)e.Row.FindControl("carga" + i);
                        //TextBox falla_ = (TextBox)e.Row.FindControl("falla" + i);
                    }
                    else
                    {
                        TextBox peso_ = (TextBox)e.Row.FindControl("peso" + i);
                        TextBox carga_ = (TextBox)e.Row.FindControl("carga" + i);
                        TextBox falla_ = (TextBox)e.Row.FindControl("falla" + i);

                        peso_.Enabled = true;
                        carga_.Enabled = true;
                        falla_.Enabled = true;
                        
                        //carga_.CssClass = "campo";
                        //falla_.CssClass = "campo";
                        //peso_.Attributes.CssStyle.Remove("campo");
                        //peso_.Attributes.CssStyle.Remove("campo");
                        //peso_.Attributes.CssStyle.Remove("campo");
                    }

                }

                //Label edad = (Label)e.Row.FindControl("lblDias");

                //if (edad.Text == "3")
                //{
                //    e.Row.BackColor = Color.AliceBlue;
                //}
                //if (edad.Text == "7")
                //{
                //    e.Row.BackColor = Color.Green;
                //}
                //if (edad.Text == "14")
                //{
                //    e.Row.ForeColor = Color.Blue;
                //}
                //if (edad.Text == "28")
                //{
                //    e.Row.BackColor = Color.Red;
                //}

            }
        }

        private void RecorreGrid()
        {

            DateTime dateRegistro = DateTime.Now;
            string userId = User.Identity.GetUserId();
       
            foreach (GridViewRow fila in grvDatos.Rows)
            {
                Label id = (Label)fila.FindControl("lblID");                
                Label lblEnsayo = (Label)fila.FindControl("lblEnsayo");  
               
                int.TryParse(id.Text, out int Id);   
                int.TryParse(lblEnsayo.Text, out int EnsayoID);

                decimal peso = 0, carga = 0, falla = 0;

                Ensayo ensa = new Ensayo();
                ensa.EdadID = Id;
                ensa.FechaRegistro = dateRegistro;
                ensa.UsuarioID = userId;
                ensa.EnsayoID = EnsayoID;

                var info = ensayoDatos.SaveEnsayo(ensa);

                /*Cajas de textos*/
                for (int i = 1; i <= 3; i++)
                {
                    Label lblEnsayoDetalle = (Label)fila.FindControl("lblEnsayoDetalle" +i);

                    int.TryParse(lblEnsayoDetalle.Text, out int EnsayoDetalleID);

                    TextBox peso_ = (TextBox)fila.FindControl("peso" + i);
                    TextBox carga_ = (TextBox)fila.FindControl("carga" + i);
                    TextBox falla_ = (TextBox)fila.FindControl("falla" + i);

                    decimal.TryParse(peso_.Text, out peso);
                    decimal.TryParse(carga_.Text, out carga);
                    decimal.TryParse(falla_.Text, out falla);

                    //string s = peso.Text + "-" + carga.Text + "-" + falla.Text;
                    if(peso != 0 && carga != 0 && falla != 0)
                        saveDetalleEnsayo(info.EnsayoID, peso, carga, falla, EnsayoDetalleID);
                }                
            }
        }

        private void saveDetalleEnsayo(int ensayoID, decimal peso, decimal carga, decimal falla, int ensayoDetalleID = 0)
        {
            EnsayoDetalle ensayoDetalle = new EnsayoDetalle();
            ensayoDetalle.EnsayoID = ensayoID;
            ensayoDetalle.Peso = peso;
            ensayoDetalle.Carga = carga;
            ensayoDetalle.Falla = falla;
            ensayoDetalle.EnsayoDetalleID = ensayoDetalleID;

            ensayoDatos.SaveDetalleEnsayo(ensayoDetalle);
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void filtroDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void grabar_Click(object sender, EventArgs e)
        {
            try
            {
                RecorreGrid();
                LabUtils.Alerta(this, "Datos Registrados con Exito!", EnumsDto.Alertas.success);
            }
            catch (Exception ex)
            {
                LabUtils.Alerta(this, $"Error:: {ex.Message}", EnumsDto.Alertas.error);
            }
            
        }
    }
}