using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemLab.Models;

namespace SystemLab
{
    public partial class ResporteVisual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //var repParams = (ParametrosReportes)Session["ReportParamData"];

                //Type report = Type.GetType(repParams.ClaseReporte);
                //object obj = Activator.CreateInstance(report);
                //MethodInfo mi = report.GetMethod("PrepararDatos");
                //mi.Invoke(obj, new object[] { repParams });

                //PropertyInfo prf = report.GetProperty("ArchivoRDL");
                //string repfile = (string)prf.GetValue(obj);
                //repfile = Server.MapPath(repfile);

                //PropertyInfo pdat = report.GetProperty("Datos");
                //object data = pdat.GetValue(obj);

                //ReportViewer.LocalReport.ReportPath = repfile;

                //ReportDataSource rds = new ReportDataSource(repParams.DataSetName, data);

                //ReportViewer.LocalReport.DataSources.Clear();
                //ReportViewer.LocalReport.DataSources.Add(rds);

                //ReportViewer.DataBind();
                //ReportViewer.LocalReport.Refresh();

            }
        }
    }
}