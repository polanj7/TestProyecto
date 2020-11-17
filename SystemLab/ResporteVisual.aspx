<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResporteVisual.aspx.cs" Inherits="SystemLab.ResporteVisual" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visualizador de Reportes</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer" runat="server" Width="100%"></rsweb:ReportViewer>
    </form>
</body>
</html>
