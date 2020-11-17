using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Controllers;
using SystemLab.Models;
using SystemLab.Utilidades;

namespace SystemLab
{
    public partial class _Default : Page
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

        private List<EnsayoDTO> GetData()
        {
            try
            {
                DateTime fecha;
                DateTime.TryParse(filtroDate.Text.Trim(), out fecha);

                var data = rResultadoEnsayo.EnsayoList(fecha);

                grvDatos.DataSource = data;
                grvDatos.DataBind();

                return data;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return null;
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void CreateTable()
        {
            string Boostrap = @"<script src='https://code.jquery.com/jquery.min.js'></script>
                                <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css' rel='stylesheet' type='text/css' />
                                <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script>";

            string head = string.Format(@"<div><h3>Roturas del {0}</h3><p>Reporte de roturas diarias, Indecal SRL</p></div>", DateTime.Now.Date.ToString("dd/MM/yyyy"));


            string a = string.Format(@"<table class='table table-bordered'>
                                          <tr padding='5' align='center' >
                                            <td width = '7%'>Registro</td>
                                            <td width = '18%'>Elemento</td>
                                            <td width = '10%'>Fecha toma</td>
                                            <td width = '8%'>Edad(dias)</td>
                                            <td width = '9%'>Probetas</td>
                                            <td width = '16%'>Peso(kg)</td>
                                            <td width = '16%'>Carga(kg)</td>
                                            <td width = '16%'>Falla</td>
                                            <td width = '16%'>Observación</td>
                                          </tr>
                                        </table>").Trim();
            var data = GetData();

            string b= "<table BORDER='1' width='100%' size='1'>";

            foreach (var i in data)
            {
                b += string.Format(@"
                            <tr padding='10' align='center'>
                                <td width = '7%'>{0}</td>
                                <td width = '18%'>{1}</td>
                                <td width = '10%'>{2}</td>
                                <td width = '8%'>{3}</td>
                                <td width = '9%'>{4}</td>
                                <td width = '16%'>                            
                                </td>
                                <td width = '16%'>                                 
                                </td>
                                <td width = '16%'>                                 
                                </td>
                                <td width = '9%'>
                                </td>
                             </tr>
                                ", i.Registro, i.Elemento, i.Fecha.ToString("dd/MM/yyyy"), i.EdadActual, i.Probetas);
            }
            string body = (a + (b+ "</table>"));


            CreatePDF(head + body.Trim());


        }

        private void CreatePDF(string cadenaHTML)
        {
            string txt = string.Empty;

            if (filtroDate.Text == string.Empty)            
                txt = DateTime.Now.ToString("ddMMyyyy");            
            else            
                txt = filtroDate.Text.Replace("-", "");            

            string Nombre = $"Rotura {txt}.pdf";

            LabUtils.GeneradorPDF(this, cadenaHTML, Nombre);
            LabUtils.DescargaPDF(this, Nombre);
            LabUtils.DeleteFile(this, Nombre);
        }

        protected void print_Click(object sender, EventArgs e)
        {
            CreateTable();
        }
    }
}