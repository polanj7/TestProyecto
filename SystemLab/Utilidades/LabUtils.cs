using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using SystemLab.Dto;

namespace SystemLab.Utilidades
{
    public static class LabUtils
    {       


        public static string GeneradorPDF(Page page, string cadenaHTML, string nombreDocumento)
        {

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringReader sr = new StringReader(cadenaHTML);

                    string CarpetaPath = Path.Combine(page.Request.PhysicalApplicationPath + "PDF\\");

                    FileStream fs = new FileStream(CarpetaPath + "\\" + nombreDocumento, FileMode.Create); /*Ruta del servidor conde guarda el File*/
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

                    //----Elimina el file si existe
                    if (File.Exists(fs.Name))
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(fs.ToString());
                    }           

                    PdfWriter w = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(w, pdfDoc, sr);
                    pdfDoc.Close();
                    //pdfDoc.HtmlStyleClass = HojaCss;
                    /*PDF*/


                    //Read string contents using stream reader and convert html to parsed conent 
                    //var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(cadenaHTML), null);
                    ////Get each array values from parsed elements and add to the PDF document 
                    //foreach (var htmlElement in parsedHtmlElements)
                    //    pdfDoc.Add(htmlElement as IElement);
                    ////Close your PDF                

                    /*PDF*/
                    return CarpetaPath + "\\" + nombreDocumento;
                }
            }



        }

        public static string DescargaPDF(Page page, string File)
        {
            string CarpetaPath = Path.Combine(page.Request.PhysicalApplicationPath + "PDF\\");

            page.Response.Clear();
            page.Response.ContentType = "application/pdf";
            page.Response.AddHeader("Content-disposition", "attachment;filename=" + File);
            page.Response.WriteFile(CarpetaPath + "\\" + File);
            page.Response.Flush();
            page.Response.Close();      
            
            return CarpetaPath +"\\" + File;
        }

        public static void DeleteFile(Page page, string Nombre)
        {
            string CarpetaPath = Path.Combine(page.Request.PhysicalApplicationPath + "PDF\\"+ Nombre);
            File.Delete(CarpetaPath); 
        }

        public static string GetDocumento()
        {
            return "";
        }

        public static void Alerta(Page page, string mensaje, EnumsDto.Alertas alertas)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Script", "AlertaNoti('" + mensaje + "', '"+ (int)alertas + "');", true);
        }

        public static void Reporte(Page page, string url)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Script", "ReporteWeb();", true);
        }

        public static bool ConectadoInternet()
        {
            bool ok = false;

            System.Uri Url = new System.Uri("https://www.google.com/");

            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objetoResp;

            try
            {
                ok = !ok;
                objetoResp = WebRequest.GetResponse();               
                objetoResp.Close();
            }
            catch (Exception e)
            {
                ok = false;
            }
            WebRequest = null;

            return ok;
        }

    }
}