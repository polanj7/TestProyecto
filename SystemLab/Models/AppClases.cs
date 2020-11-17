using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemLab.Models
{
    [Serializable]
    public class ParametrosReportes
    {
        private string dsName = "DataSet1";
        public string DataSetName
        {
            get { return dsName; }
            set { dsName = value; }
        }
        public string ClaseReporte { get; set; }
        public int CampoInt1 { get; set; }
        public int CampoInt2 { get; set; }
        public int CampoInt3 { get; set; }
        public string CampoString1 { get; set; }
        public string CampoString2 { get; set; }
        public string CampoString3 { get; set; }
        public string CampoString4 { get; set; }
        public DateTime? CampoDate1 { get; set; }
        public DateTime? CampoDate2 { get; set; }
        public DateTime? CampoDate3 { get; set; }
        public DateTime? CampoDate4 { get; set; }
        public double CampoDouble1 { get; set; }
        public double CampoDouble2 { get; set; }

    }

    /// <summary>
    /// Clase default para los reportes del sistema
    /// </summary>
    public abstract class ReporteDefault
    {
        public string ArchivoRDL { get; set; }
        public object Datos { get; set; }
        public abstract void PrepararDatos(ParametrosReportes p);

    }
}