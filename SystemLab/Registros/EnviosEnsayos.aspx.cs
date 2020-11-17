using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Controllers;
using SystemLab.Models;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using SystemLab.Utilidades;
using SystemLab.Dto;

namespace SystemLab.Registros
{
    public partial class EnviosEnsayos : System.Web.UI.Page
    {
        private DatosEnvios rDatos = new DatosEnvios();
        private ApplicationDbContext ctx = new ApplicationDbContext();
        ClientsDatos clients = new ClientsDatos();


        class Proyec
        {
            public string Id { get; set; }
            public string Proyecto { get; set; }
        }
  

        /*Dimension 10x20*/
        const double area1 = 78.54;
        /*Dimension 15x30*/
        const double area2 = 176.71;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {    
                LlenaCliente();
                LlenaProyecto();

                CargaGrid();
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

        private void CargaGrid2(int Id, GridView grv)
        {
            var data = (from a in rDatos.RegistroDetalleLists(Id)
                        select new {
                            a.Id,
                            a.subregistro,
                            a.resistencia,
                            a.elemento,
                            a.sector,
                            vaciado = a.vaciado.ToString("dd/MM/yyyy")
                        }).AsEnumerable();

            grv.DataSource = data.ToList();
            grv.DataBind();

        }

        private void CargaGrid3(int Id, GridView grv)
        {
            var data = rDatos.RegistroDetalleEdadLists(Id);

            grv.DataSource = data;
            grv.DataBind();

        }

        protected void grvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblID = (Label)e.Row.FindControl("lblID");
                GridView grv = (GridView)e.Row.FindControl("grvDatos2");
                
                int.TryParse(lblID.Text, out int ID);
                CargaGrid2(ID, grv);
            }
        }

        protected void grvDatos2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblID = (Label)e.Row.FindControl("lblID");
                GridView grv = (GridView)e.Row.FindControl("grvDatos3");
                
                int.TryParse(lblID.Text, out int ID);

                CargaGrid3(ID, grv);
            }
        }             

        private void SendEmail(int Id, string ruta)
        {
            if (LabUtils.ConectadoInternet())
            {
                lblSuccess.Text = string.Empty;
                lblDanger.Text = string.Empty;
                var user = ConfigurationManager.AppSettings["EmailSender"];
                var pass = ConfigurationManager.AppSettings["PassEmail"];

                var dataBody = (from i in ctx.Edads
                                where i.RegistroDetalle.RegistroID == Id
                                select i).AsQueryable();

                //------No deja que se envie si no tiene resultados
                if (dataBody.Count() == 0)
                    return;                

                MailMessage correos = new MailMessage();
                SmtpClient envios = new SmtpClient();
                correos.IsBodyHtml = true;
                correos.Body = "<p style='color: red;'>Esta es una prueba de envío de reporte.</p>";




                if (!File.Exists(ruta))
                {
                    LabUtils.Alerta(this, "Error, el reporte no pudo ser generado!", EnumsDto.Alertas.error);
                    return;
                }

                if (dataBody.FirstOrDefault()?.RegistroDetalle.Registro.Contacto == "")
                {
                    LabUtils.Alerta(this, "No posee contacto registrado!", EnumsDto.Alertas.warning);
                    return;
                }

                Attachment archivo = new Attachment(ruta);
                string Contacto = dataBody.FirstOrDefault()?.RegistroDetalle.Registro.Contacto;

                correos.Attachments.Add(archivo);
                correos.Subject = "Servicios Indecal, Reporte de Laboratorio";
                correos.To.Add(Contacto);
                correos.From = new MailAddress(user);

                /*Credenciales email*/
                envios.Credentials = new NetworkCredential(user, pass);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;
                envios.Send(correos);
                envios.Dispose();

                //-----------------------Graba la evidencia del log de envios de correos con su ultima fecha mas el total de envios realizados
                dataBody.FirstOrDefault().RegistroDetalle.Registro.FechaUltimoEmail = DateTime.Now.ToString("dd/MM/yyyy");
                dataBody.FirstOrDefault().RegistroDetalle.Registro.CantidadEmailEnviados += 1;


                if (ctx.SaveChanges() > 0)
                {
                    LabUtils.Alerta(this, "Reporte enviado con exito!", EnumsDto.Alertas.info);
                }
                else
                    LabUtils.Alerta(this, "Error, el reporte no pudo ser enviado.", EnumsDto.Alertas.error);
            }
            else
            {
                LabUtils.Alerta(this, "Error, verifique su conexión de internet.", EnumsDto.Alertas.error);
            } 
        }

        private string getDataHTML(int Id)
        {
            string CarpetaPath = Path.Combine(Request.PhysicalApplicationPath + "Images\\logoindecal.png");

            var date = DateTime.Now.Date.ToShortDateString();

            var Proyecto = (from i in ctx.EnsayoDetalles
                        where i.Ensayo.Edad.RegistroDetalle.RegistroID == Id
                        select new {
                            Nombre = i.Ensayo.Edad.RegistroDetalle.Registro.Cliente.Name,
                            Proyectos = i.Ensayo.Edad.RegistroDetalle.Registro.Proyecto,
                            Direcciondd = i.Ensayo.Edad.RegistroDetalle.Registro.Direccion,
                            FechaReporte = date,                          
                            Responsable = "-",
                            FechaVaciadosd = i.Ensayo.Edad.RegistroDetalle.FechaVaciado,
                            Registro = i.Ensayo.Edad.RegistroDetalle.Registro.NoRegistro
                        }).FirstOrDefault();

            //<img src='../../Images/logoindecal.png' alt='Alternate Text' />

            if (Proyecto == null)
                return ""; //Mensaje: Aun no tiene resultados para generar el PDF

            string a = "";
            a = string.Format($@"<table BORDER='1'>
                                    <tr>
                                      <td width='20%' style='color:red;'>
                                          <img src='{CarpetaPath}' alt='Alternate Text' />
                                      </td>
                                      <td>
                                       <table BORDER='1'>
                                         <tr>
                                           <td colspan = '2' height='10px'>
                                              <H3 align='center'><B>LABORATORIO DE MATERIALES</B></H3>
                                            </td> 
                                          </tr> 
                                           <tr align='center'>  
                                             <td width='85%'>
                                                 <b>FICHA TECNICA HORMIGON APLICADO EN OBRA</b>
                                                 <br>
                                                 <p size='40px'>ASTM C31 - Making and Curing Concrete Test Especimenes in the Field</p>
                                           </td>
                                           <td width='15%' size='35px'>
                                             <p>No.Documento</p>
                                             <p>IND-FE-L-006.1</p>
                                           </td>                                 
                                         </tr>
                                       </table>
                                      </td>
                                    </tr>                                    
                                  </table>
                                  <table BORDER='1'>
                                    <tr align='center'  size='60px'> 
                                        <td>CLIENTE: {0}</td>
                                        <td>PROYECTO: {1}</td>
                                        <td>DIRECCION: {2}</td>
                                        <td>FECHA REPORTE: {3}</td>
                                        <td>No. Registro Lab.</td>
                                    </tr>
                                    <tr align='center'  size='60px'>
                                        <td>Tipo hormigon: - </td>
                                        <td>Hormigonera: {4}</td>
                                        <td>Resp. em Obra: N/A</td>
                                        <td>Fecha vaciado {5}</td>
                                        <td>{6}</td>
                                    </tr>
                                    <tr>
                                        <td colspan = '10'  height='10px'>
                                        </td>
                                    </tr>                                   
                            </table>
                            <table BORDER = '1'>
                                <tr align='center'  size='50px'>
                                    <td>CONDUCE CAMION</td>
                                    <td>FECHA/HORA LLEGADA</td>
                                    <td>HORA FINAL VACIADO</td>
                                    <td>RESIST. F'c (Kg/cm2)</td>
                                    <td>SLUMP (Pulg)</td>
                                    <td>TEMP (oC)</td>
                                    <td>No. Reg.</td>
                                    <td>Cant.</td>
                                    <td>Diamentro x Largo(cm)</td>
                                    <td>NOMBRE DE ELEMENTO/ESTRUCTURA</td>
                                    <td>SECTOR</td>                                    
                                    <td>7 Dias</td>    
                                    <td>14 Dias</td>    
                                    <td>28 Dias</td>    
                                </tr>                    
                            </table>
                                ", Proyecto.Nombre, Proyecto.Proyectos, Proyecto.Direcciondd, Proyecto.FechaReporte, /*Proyecto.TipoHormigon*/"Concretera", Proyecto.FechaVaciadosd, Proyecto.Registro);


            string body = "";

            var dataBody = (from i in ctx.Edads
                            where i.RegistroDetalle.RegistroID == Id
                            select new {
                                
                                Conduce = i.Conduce,
                                HoraLlegada = i.RegistroDetalle.HoraInicial,
                                HoraFinal = i.RegistroDetalle.HoraFinal,
                                Resistencia = i.RegistroDetalle.Resistencia,
                                Slump = i.RegistroDetalle.Slump,
                                Temp = i.RegistroDetalle.Temp,
                                Registro = i.RegistroDetalle.Registro.NoRegistro,
                                Probetas = i.CantidadProbetas,
                                Diametro = i.Dimension,
                                Elemento = i.RegistroDetalle.Elemento,
                                Sector = i.RegistroDetalle.Sector,
                                Email = i.RegistroDetalle.Registro.Cliente.Emails
                            }).ToList();

            foreach (var item in dataBody)
            {
                body += string.Format(@"<table BORDER = '1'>
                    <tr align='center'  size='40px'>
                        <td>{0}</td>
                        <td>{1}</td>
                        <td>{2}</td>
                        <td>{3}</td>
                        <td>{4}</td>
                        <td>{5}</td>
                        <td>{6}</td>
                        <td>{7}</td>
                        <td>{8}</td>
                        <td>{9}</td>
                        <td>{10}</td>
                        <td>00.00 | 00.00%</td>
                        <td>00.00 | 00.00%</td>
                        <td>00.00 | 00.00%</td>
                    </tr>
                    </table>  ", item.Conduce, 
                                 item.HoraLlegada, 
                                 item.HoraFinal, 
                                 item.Resistencia, 
                                 item.Slump, 
                                 item.Temp, 
                                 item.Registro, 
                                 item.Probetas, 
                                 item.Diametro, 
                                 item.Elemento, 
                                 item.Sector);
            }





            string test = @"<div class='divHeader'>    
                                    <div>          
                                        LOGO AQUI
                                    </div>
                                    <div>                                        
                                        <div style='border:3px solid; border-color:blue;margin:0 auto;'></div>
                                        <p>Santo Domingo / Bávaro, email: info@indecalsrl.com  Teléfono Oficina 809-375-6085</p>
                                        <p><strong>www.indecalsrl.com</strong></p>
                                    </div>
                                     
                            </div>";






            return test;

        }

        protected void grvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id;

            if (e.CommandName == "send")
            {
                contacto.Text = string.Empty;
                DateTime date = DateTime.Now;
                string NombreDocumento = $"Reporte Indecal{date.ToString("ddMMyyyyhhmmss")}.pdf";

                int.TryParse(e.CommandArgument.ToString(), out Id);

                /*Obtengo la data*/
                string html = getDataHTML(Id);
                if (!string.IsNullOrEmpty(html))
                {
                    //var rutaDescarga = LabUtils.GeneradorPDF(this, html, NombreDocumento);
                    /*Capturo el contacto"Email"*/
                    contacto.Text = GetContactoByRegistro(Id);
                    /*Modal Email*/
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "modalEmail();", true);
                    
                    //SendEmail(Id, rutaDescarga);
                }
                else
                {
                    LabUtils.Alerta(this, "Error, no hay data disponible para este registro.", EnumsDto.Alertas.warning);
                }               
            }
            else if (e.CommandName == "download")
            {
                int.TryParse(e.CommandArgument.ToString(), out Id);         

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "ReporteWeb();", true);
            }
            //else if (e.CommandName == "verFile")
            //{
            //    int.TryParse(e.CommandArgument.ToString(), out Id);

            //    var d = ctx.Registros.Find(Id);

            //    Session["verFileRegistroID"] = d.NoRegistro+"#"+Id;
            //    Response.Redirect("~/Mantenimiento/DocXS.aspx");
            //}
        }

        private void LlenaCliente()
        {
            var dataCl = clients.getClients();

            dataCl.Insert(0, new Cliente { ClientID = 0, Name = "-" });
            dataCl.Insert(1, new Cliente { ClientID = -1, Name = "- Agregar Nuevo Cliente -" });

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

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CargaGrid();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private double CalculoResistencia(string dimension, double carga)
        {
            double resistencia = 0;   
            
            if (dimension == "10x20")            
                resistencia = (carga / area1);            
            else if (dimension == "15x30")            
                resistencia = (carga / area2);          
            
            return resistencia;
        }

        protected void grvDatos3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string RIList = "";
                string CarIList = "";               

                Label lblId = (Label)e.Row.FindControl("lblId");
                Label lblD = (Label)e.Row.FindControl("lblD");/*Dimension*/
                Label lblC = (Label)e.Row.FindControl("lblC");
                Label lblR = (Label)e.Row.FindControl("lblR"); /*Resisntecai promedio*/
                Label lblRI = (Label)e.Row.FindControl("lblResInd"); /*Resistemcia individuales*/
                Label lblRP = (Label)e.Row.FindControl("lblRP");/*Porcentaje de Resistencia*/
                Label lblCargasInd = (Label)e.Row.FindControl("lblCargasInd"); /*Cargas*/
                 
                double.TryParse(lblC.Text, out double carga);     
                int.TryParse(lblId.Text, out int id);                

                var data = ctx.EnsayoDetalles.Where(p=> p.Ensayo.EdadID == id);

                foreach (var i in data)
                {
                    /*Calculo de resistencia promedio*/
                    if (CarIList == string.Empty)
                         CarIList += i.Carga.ToString("N0");
                    else
                        CarIList += " / " + i.Carga.ToString("N0");
                    
                    double.TryParse(i.Carga.ToString(), out double carga2);

                    if(RIList == string.Empty)
                        RIList = CalculoResistencia(lblD.Text, carga2).ToString("N0");
                    else
                        RIList += " / " + CalculoResistencia(lblD.Text/*Dimension*/, carga2).ToString("N0");
                }
                //----------------------------------Resistencia promedio---------------------------
                /*Calculo de la resistencia*/
                var d = CalculoResistencia(lblD.Text, carga);
                lblR.Text = d.ToString("N2"); /*Resistencia promedio*/
                //----------------------------------Fin - Resistencia promedio---------------------

                //---------------------------------Porcentaje de resistencias----------------------
                if (data.Count() >0)
                {
                    //-----------------------------Obtengo la resistencia general--------------------------------------------
                    if (data.FirstOrDefault().Ensayo.Edad.RegistroDetalle.Resistencia > 0)
                    {
                        decimal PorcentajeResistencia = (Convert.ToDecimal(d) / data.FirstOrDefault().Ensayo.Edad.RegistroDetalle.Resistencia) * 100;
                        lblRP.Text = PorcentajeResistencia.ToString("N2") + "%";
                    }
                    else                   
                        lblRP.Text = "No Res.";                    
                }
                
                lblCargasInd.Text = CarIList;
                lblRI.Text = RIList;
            }
        }        

        private void CreatePDF(string cadenaHTML, string registro)
        { 
            string Nombre = $"Reporte de Datos{registro}.pdf";
            
            
            
        }

        protected void envio_Click(object sender, EventArgs e)
        {      
            if (cargaPDF.HasFile)
            {

                string path = Server.MapPath("~/PDF/" + cargaPDF.FileName);
                //----Elimina el file si existe
                if (File.Exists(path))
                {
                    FileInfo fi = new FileInfo(path);
                    fi.Delete();                    
                }

                cargaPDF.SaveAs(Server.MapPath("~/PDF/"+ cargaPDF.FileName));
                lblCarga.Text = cargaPDF.FileName;
                lblCarga.CssClass = "label label-success";
            }
            else
            {
                lblCarga.Text = "Primero debe seleccionar un archivo.";
                lblCarga.CssClass = "label label-danger";
            }
        }

        private string GetContactoByRegistro(int id)
        {
            string contacto = string.Empty;

            var data = ctx.Registros.Find(id);
            if (data != null)
                contacto = data.Contacto;

            return contacto;
        }
      
    }
}