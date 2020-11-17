using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using SystemLab.Controllers;
using SystemLab.Models;
using System.Web.UI;
using SystemLab.Utilidades;
using SystemLab.Dto;

namespace SystemLab.Registros
{
    public partial class RegistrosHormigon : System.Web.UI.Page
    {
        private RegistroDatos rDatos = new RegistroDatos();
        private RegistroDetalleDatos rDetalleDatos = new RegistroDetalleDatos();
        private EdadDatos rEdadDatos = new EdadDatos();
        private static ApplicationDbContext ctx = new ApplicationDbContext();
        static string CarpetaPath;

        protected void Page_Load(object sender, EventArgs e)
        {          

            if (!IsPostBack)
            {
                //fileButton.Attributes.Add("onclick", "document.getElementById('" + fileCarga.ClientID + "').click(); return false");
                CarpetaPath = Path.Combine(Request.PhysicalApplicationPath, "PDF");

                ClientesList();
                ElaboracionList();
                //CargarHormigonera();
                //CargarElemento();
            }            
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRegistro();                
            }
            catch (Exception ex)
            {
                Console.Write(ex);                
            }
           
        }

        private void SaveRegistro()
        {
            
            int RegistroID;
            int.TryParse(hdRegistroID.Value, out RegistroID);

            int ClienteID;
            int.TryParse(cliente.SelectedValue, out ClienteID);


            if (ClienteID == 0)
            {
                LabUtils.Alerta(this, "Error, Seleccione el cliente", EnumsDto.Alertas.error);
                return;
            }


            try
            {
                Registro reg = new Registro();
                reg.ClientID = ClienteID;
                reg.NoRegistro = registro.Text.Trim();
                reg.Proyecto = proyecto.Text.Trim();
                reg.Volumen = volumen.Text.Trim();
                reg.Direccion = direccion.Text.Trim();
                reg.RegistroID = RegistroID;
                reg.CantidadEmailEnviados = 0;
                reg.FechaUltimoEmail = "N/A";
                reg.Elaboracion = elaboracion.Text;
                reg.Contacto = contacto.Text;

                //Devuelve el ID del Registro actual
                hdRegistroID.Value = rDatos.SaveRegistros(reg).RegistroID.ToString();

                if (hdRegistroID.Value != "0")
                {
                    subregistro.Enabled = true;
                    //brnSaveImage.Visible = true;
                    LabUtils.Alerta(this, "Los cambios se aplicaron con exito!", EnumsDto.Alertas.success);                    
                }                    
                else
                {
                    subregistro.Enabled = false;
                    //brnSaveImage.Visible = false;
                    LabUtils.Alerta(this, "Error, registro no se pudo grabar los cambios.", EnumsDto.Alertas.error);             
                }                 

            }
            catch (Exception ex)
            {
                LabUtils.Alerta(this, ex.Message, EnumsDto.Alertas.error);
            }
            
        }

        private bool SaveRegistroDetalle()
        {
            int RegistroID;
            int.TryParse(hdRegistroID.Value, out RegistroID);

            decimal Resistencia;
            decimal.TryParse(resistencia.Text.Trim(), out Resistencia);

            decimal Slump;
            decimal.TryParse(slump.Text.Trim(), out Slump);

            decimal Temp;
            decimal.TryParse(temperatura.Text.Trim(), out Temp);

            decimal CantProbetas;
            decimal.TryParse(probetastotal.Text.Trim(), out CantProbetas);

            DateTime vaciadoDate;
            DateTime.TryParse(vaciado.Text, out vaciadoDate);

            DateTime entregaDate;
            DateTime.TryParse(entrega.Text, out entregaDate);

            if (subregistro.Text == string.Empty)
            {                
                LabUtils.Alerta(this, "Error, debe colocar el Sub-Registro, favor de completar.", EnumsDto.Alertas.error);
                subregistro.Focus();
                return false;
            }

            if (CantProbetas == 0)
            {               
                LabUtils.Alerta(this, "Error, debe colocar el la Cantidad de Probetas, favor de completar.", EnumsDto.Alertas.error);
                probetastotal.Focus();
                return false;
            }

            if (vaciadoDate < (DateTime.Now.AddYears(-10)))
            {            
                LabUtils.Alerta(this, "Error, debe colocar la fecha de Vaciado, favor de completar.", EnumsDto.Alertas.error);
                vaciado.Focus();
                return false;
            }

            if (entregaDate < (DateTime.Now.AddYears(-10)))
            {              
                LabUtils.Alerta(this, "Error, debe colocar la fecha de Entrega, favor de completar.", EnumsDto.Alertas.error);
                entrega.Focus();
                return false;
            }
          
            RegistroDetalle reg = new RegistroDetalle();
            reg.RegistroID = RegistroID;
            reg.SubRegistro = subregistro.Text.Trim();
            reg.HoraInicial = inicial.Text.Trim();
            reg.HoraFinal = final.Text.Trim();
            reg.Resistencia = Resistencia;
            reg.Slump = Slump;
            reg.Temp = Temp;
            reg.Elemento = elemento.Text.Trim();
            reg.Sector = sector.Text.Trim();  
            reg.Curado = curado.Text.Trim();
            reg.Agregado = agregado.Text.Trim();
            reg.FechaVaciado = vaciadoDate; 
            reg.FechaEntrega = entregaDate;
            reg.Hormigonera = hormigonera.Text.Trim();
            reg.TotalProbetas = CantProbetas;
            reg.Conduce = txtConduceG.Text.Trim();

            rDetalleDatos.SaveRegistros(reg);

            subregistro.Text = string.Empty;
            subregistro.Focus();

            return true;

        }

        private void FindRegistro(string e)
        {      
            var data = rDatos.GetRegistro(e);

            if (data == null)
            {                
                return;
            }

            registro.Text = data.NoRegistro;
            proyecto.Text = data.Proyecto;
            cliente.SelectedValue = data.ClientID.ToString();          
            volumen.Text = data.Volumen;
            direccion.Text = data.Direccion;
            elaboracion.Text = data.Elaboracion;
            contacto.Text = data.Contacto;

            hdRegistroID.Value = data.RegistroID.ToString();

            if (hdRegistroID.Value != "0")
            {
                subregistro.Enabled = true;
            }
            else
            {
                subregistro.Enabled = false;
                //brnSaveImage.Visible = false;               
            }
        }

        private void FindRegistroDetalle(string SubReg)
        {
            Session["Edad"] = null;

            var data = rDetalleDatos.GetSubRegistro(SubReg);

            if (data == null)
            {
                return;
            }

            vaciado.TextMode = TextBoxMode.DateTime;
            entrega.TextMode = TextBoxMode.DateTime;

            subregistro.Text = data.SubRegistro;
            inicial.Text = data.HoraInicial;
            final.Text = data.HoraFinal;
            resistencia.Text = data.Resistencia.ToString();
            slump.Text = data.Slump.ToString();
            temperatura.Text = data.Temp.ToString();
            elemento.Text = data.Elemento;
            sector.Text = data.Sector;
            //elaboracion.SelectedValue = data.Elaboracion;
            curado.Text = data.Curado;
            agregado.Text = data.Agregado;
            vaciado.Text = data.FechaVaciado.ToString("MM/dd/yyyy");
            entrega.Text = data.FechaEntrega.ToString("MM/dd/yyyy");
            hormigonera.Text = data.Hormigonera;
            probetastotal.Text = data.TotalProbetas.ToString("N2");
            txtConduceG.Text = data.Conduce;

            hdRegistroDetalleID.Value = data.ID.ToString();
       

            //edades = (from a in ctx.Edads
            //              where a.RegistroDetalle.SubRegistro == data.SubRegistro
            //              select new EdadDTO {
            //                  ID = a.ID,
            //                  CantidadProbetas = a.CantidadProbetas,
            //                  Dias = a.Dias,
            //                  Conduce = a.Conduce,
            //                  //TotalProbetas = a.TotalProbetas,
            //                  Dimension = a.Dimension,
            //                  Nueva = false
            //              }).ToList();


            //var k = (from h in edades
            //         select new
            //         {
            //             Id = h.ID,
            //             Desc = h.CantidadProbetas + " probs. a " + h.Dias + " dias, Dimension " + h.Dimension

            //         }).ToList();

            //if (Session["Edad"] == null)
            //{
            //    Session["Edad"] = edades;
            //}


            //lista.DataSource = k;
            //lista.DataBind();

            //lista.DataTextField = "Desc";
            //lista.DataValueField = "ID";

            //if (edades.Count() > 0)
            //{
            //    btnremoverEdad.Enabled = true;
            //}

            //hdRegistroID.Value = data.ClientID.ToString();

        }

        private void DeleteRegistro(string SubReg)
        {
            rDetalleDatos.DeleteRegistro(SubReg);
           
        }
    
        protected void registro_TextChanged(object sender, EventArgs e)
        {
            lblMensajeDanger.Text = string.Empty;
            lblMensajeSuccess.Text = string.Empty;

            try
            {
                FindRegistro(registro.Text.Trim());
                LlenaGrid(registro.Text.Trim());
            }
            catch (Exception ex)
            {
                Console.Write(ex);                
            }
        }

        protected void grabar_Click(object sender, EventArgs e)
        {
            lblMensajeDanger.Text = string.Empty;
            lblMensajeSuccess.Text = string.Empty;
            lblSubregistroActual.Text = string.Empty;

            try
            {

                if (SaveRegistroDetalle())
                {                    
                    LimpiarCamposEdad();
                    LlenaGrid(registro.Text.Trim());

                    lblMensajeSuccess.Text = "";
                    LabUtils.Alerta(this, "Registro compleatado con exito.", EnumsDto.Alertas.success);
                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex);                
            }
            
        }     

        protected void add_Click(object sender, EventArgs e)
        {               
            int.TryParse(hdRegistroDetalleID.Value, out int subRegistroID);
            int.TryParse(hdEdadID.Value, out int EdadID);
            hdEdadID.Value = "0";
            try
            {
                int.TryParse(dias.Text, out int d);               
                int.TryParse(cantidad.Text, out int cp);

                if (cp < 1)
                {
                    LabUtils.Alerta(this, "Error, debe colocar la Cantidad de Probetas.", EnumsDto.Alertas.error);
                    return;
                }
                else if (d < 1)
                {                   
                    LabUtils.Alerta(this, "Error, debe colocar la cantidad de Días.", EnumsDto.Alertas.error);
                    return;
                }
                else if (!ValidaCantidadProbetas(subRegistroID))
                {
                    LabUtils.Alerta(this, "La cantidad no puede ser mayor al total de probetas.", EnumsDto.Alertas.error);
                    return;
                }

                var conduceG = ctx.RegistroDetalles.Where(o=> o.ID == subRegistroID).AsQueryable();

                if (EdadID == 0)
                {
                    Edad edad = new Edad();
                    edad.Dias = d;
                    edad.CantidadProbetas = cp;
                    edad.Dimension = dimension.SelectedItem.Text;
                    edad.SubRegistroID = subRegistroID;
                    if (conduceG.Count() > 0 && conduce.Text == string.Empty)
                        edad.Conduce = conduceG.FirstOrDefault().Conduce;
                    else if (conduce.Text != string.Empty)
                        edad.Conduce = conduce.Text.Trim();
                    ctx.Edads.Add(edad);

                    //---Vaoida si el check esta seleccionado para clonar los registros
                    if (chkClon.Checked)
                        ClonacionEdad(edad);
                }
                else
                {
                    var data = ctx.Edads.Find(EdadID);
                    if (data != null)
                    {
                        data.CantidadProbetas = cp;
                        data.Dias = d;
                        data.Dimension = dimension.Text;
                        data.Conduce = conduce.Text;
                    }
                }

                var s = ctx.SaveChanges();

                //---Carga la edad para mostrarla en el list view
                CargaEdades(subRegistroID);

                dias.Text = string.Empty;
                cantidad.Text = string.Empty;
                hdEdadID.Value = "0";
                //---Recarga el grid
                LlenaGrid(registro.Text.Trim());      
                
                lblProbetasFaltantes.Text = ProbetasFaltantes(subRegistroID).ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void lista_TextChanged(object sender, EventArgs e)
        {
            var ls = sender;
            var sk = e;
        }

        private void LlenaGrid(string reg)
        {
            var data = (from  i in rDatos.GetRegistrosDetalle(reg)
                        select new {
                            id = i.ID,
                            subregistro = i.SubRegistro,
                            fecha = i.FechaVaciado.ToString("dd/MM/yyyy"),
                            edad = (ctx.Edads.Where(j=> j.SubRegistroID == i.RegistroID)).ToList(),
                            elemento = i.Elemento,
                            sector = i.Sector,
                            slump = i.Slump,
                            temp = i.Temp,
                            resistencia = i.Resistencia
                        }).ToList();

            grvDatos.DataSource = data;
            grvDatos.DataBind();
        }

        

        protected void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
               
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }


        }

        private void LimpiarCamposPrincipales()
        {
            subregistro.Text = string.Empty;
            inicial.Text = string.Empty;
            final.Text = string.Empty;
            resistencia.Text = string.Empty;
            slump.Text = string.Empty;
            temperatura.Text = string.Empty;
            elemento.Text = string.Empty;
            sector.Text = string.Empty;
            curado.Text = string.Empty;
            agregado.Text = string.Empty;
            vaciado.Text = string.Empty;
            entrega.Text = string.Empty;            
        }

        private void LimpiarCamposEdad()
        {
            dias.Text = string.Empty;
            cantidad.Text = string.Empty;
            conduce.Text = string.Empty;
            //subregistro.Text = string.Empty;

            //lista.Items.Clear();
        }

        private void ClientesList()
        {
            var data = (from a in ctx.Clients
                        select new { Id = a.ClientID, a.Name }).ToList();

            data.Insert(0, new { Id = 0, Name = "-" });

            cliente.DataSource = data;
            cliente.DataTextField = "Name";
            cliente.DataValueField = "Id";
            cliente.DataBind();
        }

        private void ElaboracionList()
        {
            var data = (from a in ctx.Responsables
                        select new { Id = a.ResponsablesID, Name = "Lab-" + a.Nombre }).ToList();

            data.Insert(0, new { Id = 0, Name = "Cliente" });
            elaboracion.DataSource = data;
            elaboracion.DataTextField = "Name";
            elaboracion.DataValueField = "Name";
            elaboracion.DataBind();
        }

        private void Limpiar()
        {
            Response.Redirect("~/Registros/RegistrosHormigon");
        }

        protected void limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void SaveEdad()
        {
            int RegistroID;
            int.TryParse(hdRegistroID.Value, out RegistroID);

            if (RegistroID == 0)
            {
                return;
            }

            foreach (var a in (List<EdadDTO>)Session["Edad"])
            {
                /*Las nuevas edades*/
                if (a.Nueva)
                {
                    ctx.Edads.Add(new Edad {

                        CantidadProbetas = a.CantidadProbetas,
                        Conduce = a.Conduce,
                        Dias = a.Dias,
                        Dimension = a.Dimension,
                        //TotalProbetas = a.TotalProbetas,
                        SubRegistroID = RegistroID
                    });

                    ctx.SaveChanges();
                }

            }

        }

        private bool EliminarEdad(int id)
        {
            bool ok = false;
            var data = ctx.Edads.Find(id);
            if (data != null)
            {
                ctx.Edads.Remove(data);
                if(ctx.SaveChanges() > 0)
                {                    
                    ok = !ok;
                }
                else
                {
                    LabUtils.Alerta(this, "Error, no se pudo eliminar la edad.!", EnumsDto.Alertas.error);
                }
            }
            else
            {
                LabUtils.Alerta(this, "La edad no existe, al parecer uya fue eliminada", EnumsDto.Alertas.warning);
            }

            return ok;
        }

        private void CargaProyecto(int cliente)
        {
            var data = ctx.Registros.Select(p => new { ClientID = p.ClientID, Proyecto = p.Proyecto, RegistroID = p.RegistroID }).Distinct().Where(o=> o.ClientID == cliente).ToList();

            if (data.Count() == 0)
            {
                cboProyecto.Visible = false;
                return;
            }

            cboProyecto.Visible = true;

            data.Insert(0, new { ClientID = 0, Proyecto = "-", RegistroID  = 0});
            cboProyecto.DataSource = data;
            cboProyecto.DataTextField = "Proyecto";
            cboProyecto.DataValueField = "Proyecto";
            cboProyecto.DataBind();                                        
        }

        protected void cliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(cliente.SelectedValue, out id);

                CargaProyecto(id);
                CargarRegistros();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void cboProyecto_TextChanged(object sender, EventArgs e)
        {
            direccion.Text = string.Empty;

            proyecto.Text = cboProyecto.SelectedItem.Text;
            
            try
            {
                var data = ctx.Registros.Select(o => new { o.Proyecto, o.Direccion }).Where(p => p.Proyecto == cboProyecto.SelectedItem.Text);

                if (data.Count() > 0)
                {
                    direccion.Text = data.FirstOrDefault().Direccion;
                    CargarRegistros(proyecto.Text);
                }

            }
            catch (Exception ex)
            {
                                
            }

        }

        private void habilitar_edad()
        {
            dias.Enabled = true;
            cantidad.Enabled = true;
            dimension.Enabled = true;
            conduce.Enabled = true;
        }

        private void inabilitar_edad()
        {
            dias.Enabled = false;
            cantidad.Enabled = false;
            dimension.Enabled = false;
            conduce.Enabled = false;
        }

        private void CargaEdades(int subID)
        {
            if (subID == 0)
                return;

            hdProbetas.Value = ctx.RegistroDetalles.Find(subID).TotalProbetas.ToString();

            var data = (from a in ctx.Edads
                        where a.SubRegistroID == subID
                        select new {
                            a.ID,
                            a.RegistroDetalle.TotalProbetas,
                            Desc = " " + a.CantidadProbetas + " a " + a.Dias + " días " + ", dimensión: " + a.Dimension + (a.Conduce != "" ? ", conduce: " + a.Conduce : "")                            
                        }).AsQueryable();

            grvEdades.DataSource = data.ToList();
            grvEdades.DataBind();
        }

        private void CargaEdad(int id)
        {

            var data = (from a in ctx.Edads
                        where a.ID == id
                        select a ).AsEnumerable();

            if (data.Count() > 0)
            {
                cantidad.Text = data.FirstOrDefault()?.CantidadProbetas.ToString();
                dias.Text = data.FirstOrDefault()?.Dias.ToString();
                dimension.SelectedValue = data.FirstOrDefault()?.Dimension;
                conduce.Text = data.FirstOrDefault()?.Conduce;                
            }

        }

        private bool ValidaCantidadProbetas(int subID)
        {            
            decimal c;
            decimal.TryParse(cantidad.Text, out c);

            decimal cc;
            decimal.TryParse(hdProbetas.Value, out cc);

            var data = (from a in ctx.Edads
                        where a.SubRegistroID == subID
                        group a by a.SubRegistroID into Gr
                        select new {                            
                            SumaCantidad = Gr.Sum(p=> p.CantidadProbetas) + c,
                            TotalProbetas = Gr.Max(p=> p.RegistroDetalle.TotalProbetas)                            
                        }).AsEnumerable();

            if (data.Count() > 0)
            {
                if (data.FirstOrDefault().SumaCantidad > data.FirstOrDefault().TotalProbetas)
                {
                    return false;
                }
            }
            else
            {
                if (c > cc)
                {
                    return false;
                }
            }

            return true;
        }

        protected void subregistro_TextChanged(object sender, EventArgs e)
        {
            lblMensajeDanger.Text = string.Empty;
            lblMensajeSuccess.Text = string.Empty;

            if (subregistro.Text == string.Empty)
                return;

            try
            {
                /*Valida que ya no exista este subregistro*/
                var data = ctx.RegistroDetalles.Where(p=> p.SubRegistro == subregistro.Text.Trim());

                if (data.Count() > 0)
                {              
                    LabUtils.Alerta(this, $"El Sub-Registro { subregistro.Text } ya existe para el Registro {  data.FirstOrDefault().Registro.NoRegistro }", EnumsDto.Alertas.warning);

                    subregistro.Text = string.Empty;
                    subregistro.Focus();
                    return;
                }

                inicial.Focus();

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void proyecto_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void CargarRegistros(string proyecto = "")
        {
            int ClienteID;
            int.TryParse(cliente.SelectedValue, out ClienteID);

            var data = (from a in ctx.Registros
                        where (a.ClientID == ClienteID)
                        && (proyecto == "" || a.Proyecto == proyecto)
                        select new {
                            a.NoRegistro
                        }).ToList();

            data.Insert(0, new { NoRegistro = "-" });
            cboRegistro.DataSource = data;
            cboRegistro.DataTextField = "NoRegistro";
            cboRegistro.DataTextField = "NoRegistro";
            cboRegistro.DataBind();
        }

        //private void CargarElemento()
        //{
        //    var data = (from a in ctx.RegistroDetalles
        //                select new { Elemento = a.Elemento }).Distinct().ToList();

        //    data.Insert(0, new { Elemento = "-" });
        //    cboElemento.DataSource = data;
        //    cboElemento.DataTextField = "Elemento";
        //    cboElemento.DataValueField = "Elemento";
        //    cboElemento.DataBind();
        //}

        //private void CargarHormigonera()
        //{
        //    var data = (from a in ctx.RegistroDetalles
        //                select new { Hormigonera = a.Hormigonera }).Distinct().ToList();

        //    data.Insert(0, new { Hormigonera = "-" });
        //    cboHormigonera.DataSource = data;
        //    cboHormigonera.DataTextField = "Hormigonera";
        //    cboHormigonera.DataValueField = "Hormigonera";
        //    cboHormigonera.DataBind();
        //}

        private void ClonacionEdad(Edad edad)
        {
            if (edad.SubRegistroID == 0)
                return;

            var idDetalle = (from a in ctx.RegistroDetalles
                        where a.ID == edad.SubRegistroID
                        select new { a.RegistroID }).AsQueryable();

            if (idDetalle.Count() == 0)
                return;

            int iddetalle = idDetalle.FirstOrDefault().RegistroID;

            var data = (from a in ctx.RegistroDetalles
                        where a.RegistroID == iddetalle && a.ID != edad.SubRegistroID
                        select new { a }).ToList();


            foreach (var item in data)
            {
                if (ValidaCantidadProbetas(item.a.ID))
                {
                    Edad _edad = new Edad();
                    _edad.Dias = edad.Dias;
                    _edad.CantidadProbetas = edad.CantidadProbetas;
                    _edad.Dimension = edad.Dimension;
                    _edad.SubRegistroID = item.a.ID;
                    _edad.Conduce = item.a.Conduce;
                    ctx.Edads.Add(_edad);                    
                }
               
            }                                 

        }

        //protected void cboHormigonera_TextChanged(object sender, EventArgs e)
        //{
        //    hormigonera.Text = cboHormigonera.SelectedValue;
        //}

        //protected void cboElemento_TextChanged(object sender, EventArgs e)
        //{
        //    elemento.Text = cboElemento.SelectedValue;
        //}

        protected void grvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string txt = "";

                Label label = (Label)e.Row.FindControl("lblID");
                Label label2 = (Label)e.Row.FindControl("lblEdad");

                int subID;
                int.TryParse(label.Text, out subID);



                var data = (from a in ctx.Edads
                            where a.SubRegistroID == subID
                            select new
                            {
                                Desc = a.CantidadProbetas + " a " + a.Dias + " dias " + ", dimensión: " + a.Dimension + (a.Conduce != "" ? ", Conduce: " + a.Conduce : "")                               
                            }).ToList();

                if (data.Count() > 0)
                {
                    foreach (var i in data)
                    {
                        if (txt == "")
                        {
                            txt = i.Desc;
                        }
                        else
                        {
                            txt = txt + "<br />" + i.Desc;
                        }
                    }

                    label2.Text = txt;

                }
            }
        }

        protected void cboRegistro_TextChanged(object sender, EventArgs e)
        {
            registro.Text = cboRegistro.SelectedItem.Text;
        }

        protected void btnClonar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private string ProbetasFaltantes(int id)
        {
            var d = (from p in ctx.Edads
                        where p.SubRegistroID == id
                        group p by p.SubRegistroID into Gr
                        select new
                        {
                            Total = (Gr.Max(o=> o.RegistroDetalle.TotalProbetas) - Gr.Sum(k => k.CantidadProbetas))

                        }).AsQueryable();

            if (d.Count() == 0)
            {
                return "";
            }

            return "Probetas restantes: " + d.FirstOrDefault().Total.ToString("N0");
        }

        public static void GuardarImagen(int ProyectoID, string PathDocX)
        {

            if (PathDocX == string.Empty || ProyectoID == 0)
            {
                return;
            }

            Documentos doc = new Documentos();
            doc.PathDocX = PathDocX;
            doc.ProyectoID = 3009;
            ctx.Documentos.Add(doc);

            ctx.SaveChanges();

        }

        public bool CargarDocX()
        {
            ////Foto Depeues
            //if (fileCarga.PostedFile.FileName == "")
            //{

            //}
            //else
            //{
            //    string Tipo = Path.GetExtension(fileCarga.PostedFile.FileName);
            //    switch (Tipo.ToLower())
            //    {
            //        case ".jpg":
            //            break;
            //        case ".jpng":
            //            break;
            //        case ".png":
            //            break;
            //        default:
            //            //lblPlan2.Text = "Los formatos para las fotos son .jpg y .Png";
            //            return false;
            //    }

            //    //Este es el nombre de la imagen
            //    string Foto = Path.GetFileName(fileCarga.PostedFile.FileName);
            //    //Ruta Completa junto con la imagen, pega la imagen en la ruta designada
            //    string CarpetaPegar = Path.Combine(CarpetaPath, Foto);
            //    //Guarda los cambios (Copiar y pegar)
            //    fileCarga.PostedFile.SaveAs(CarpetaPegar);

            //    byte[] data = System.IO.File.ReadAllBytes(CarpetaPegar);

            //    ////Elimina la foto del directorio temporal
            //    System.IO.FileInfo fi = new System.IO.FileInfo(CarpetaPegar);
            //    fi.Delete();

            //    int RegistroID;
            //    int.TryParse(hdRegistroID.Value, out RegistroID);

            //    if (RegistroID == 0)
            //    {
            //        return false;
            //    }

            //    //Guardar fotos
            //    ctx.Documentos.Add(new Documentos {
            //    ProyectoID = RegistroID,
            //    DocXHash = data,
            //    PathDocX = "MMG aqui no buscas Nada"
            //    });

            //    if (ctx.SaveChanges() > 0)
            //        return true;

            //}

            return false;


        }

        protected void brnSaveImage_Click(object sender, EventArgs e)
        {
           
            if(CargarDocX())
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Archivo cargado con exito.')", true);
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Error al intentar cargar el archivo.')", true);
        }

        protected void grvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblProbetasFaltantes.Text = string.Empty;
            lblMensajeDanger.Text = string.Empty;
            lblMensajeSuccess.Text = string.Empty;

            string r = "";

            if (e.CommandName == "editar")
            {
                r = e.CommandArgument.ToString();
                FindRegistroDetalle(r);
                lblmodo.InnerText = "Datos (Modo edición)";
            }
            else if (e.CommandName == "modal")
            {
                int.TryParse(e.CommandArgument.ToString(), out int id);

                habilitar_edad();
                CargaEdades(id);
                hdRegistroDetalleID.Value = id.ToString();
                lblProbetasFaltantes.Text = ProbetasFaltantes(id).ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "modalEdad();", true);
            }
            else if (e.CommandName == "dell")
            {
                LabUtils.Alerta(this, "Los cambios se aplicaron con exito!", EnumsDto.Alertas.success);

                r = e.CommandArgument.ToString();
                DeleteRegistro(r);
                LlenaGrid(registro.Text);
                
            }
        }

        protected void grvEdades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                int.TryParse(e.CommandArgument?.ToString(), out int id);
                hdEdadID.Value = id.ToString();

                CargaEdad(id);
            }
            else if (e.CommandName == "delete")
            {
                int.TryParse(e.CommandArgument?.ToString(), out int id);
                var ok = EliminarEdad(id);

                if (ok)
                {
                    //CargaEdades(data.SubRegistroID);
                    //LlenaGrid(registro.Text.Trim());
                    //lblProbetasFaltantes.Text = ProbetasFaltantes(data.SubRegistroID).ToString();

                    LabUtils.Alerta(this, "Los cambios se aplicaron con exito!", EnumsDto.Alertas.success);
                }

            }
        }        
    }
}