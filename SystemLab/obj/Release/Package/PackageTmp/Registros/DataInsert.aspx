<%@ Page Title="Ensayo de datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataInsert.aspx.cs" Inherits="SystemLab.Registros.DataInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style type="text/css">
        .campos{
            
            margin:3px;
            border-color:red;
            border:solid 1px;
            
        }

        .txt{
            padding:1px; 
            font-size:15px;
        }
    </style>



    <br />    
    
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Ensayo de resistencia a Compresión en pruebas de cilindros de Hormigón</h4>
        </div>
        <div class="panel-body">

   

    <div class="row"> 
        <div class="col-md-8">
        </div>
        <div class="col-md-3">
            <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="filtroDate" OnTextChanged="filtroDate_TextChanged"  />
        </div>
         <div class="col-md-1">
             <asp:LinkButton Text="Buscar" runat="server" ID="buscar" CssClass="btn btn-default" Width="100%" OnClick="buscar_Click" />
        </div>
    </div>
    <br />
   
     <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="grvDatos_RowDataBound">
         <RowStyle Font-Size="Larger" />
         <HeaderStyle BackColor="#53ABC8" ForeColor="#e4ecf3" />
         <EmptyDataTemplate>
             <h4>No hay pruebas para esta fecha!</h4>
         </EmptyDataTemplate>
         <EmptyDataRowStyle BackColor="#6d0e1e" ForeColor="Window" HorizontalAlign="Center" />
        <Columns>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label Text='<%# Bind("Id") %>' runat="server" ID="lblID" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>                    
                    <asp:Label runat="server" ID="lblEnsayo" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Registro">
                <ItemTemplate>
                    <asp:Label Text='<%# Bind("Registro") %>' runat="server" ID="lblRegistro" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Elemento" HeaderText="Elemento Estructural" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha Toma" />
            <asp:TemplateField HeaderText="Edad">
                <ItemTemplate>
                    <asp:Label Text='<%# Bind("Dias") %>' runat="server" ID="lblDias" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EdadActual" HeaderText="Edad actual" />
            <asp:BoundField DataField="Probetas" HeaderText="Total Probetas" />
            <asp:TemplateField ControlStyle-CssClass="campos" HeaderText="Peso(kg)">
                <ItemStyle ForeColor="orange" Width="20px" />
                <ControlStyle Width="65px"  />
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblEnsayoDetalle1" Visible="false" />
                    <asp:Label runat="server" ID="lblEnsayoDetalle2" Visible="false" />
                    <asp:Label runat="server" ID="lblEnsayoDetalle3" Visible="false" />
                    <asp:TextBox runat="server" ID="peso1" TextMode="Number"/>
                    <asp:TextBox runat="server" ID="peso2" TextMode="Number"/>
                    <asp:TextBox runat="server" ID="peso3" TextMode="Number"/>                
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField ControlStyle-CssClass="campos" HeaderText="Carga(kg)">
                <ItemStyle ForeColor="red" Width="20px" />
                <ControlStyle Width="65px"  />
                <ItemTemplate>        
                    <asp:TextBox runat="server" ID="carga1" TextMode="Number" />
                    <asp:TextBox runat="server" ID="carga2" TextMode="Number" />
                    <asp:TextBox runat="server" ID="carga3" TextMode="Number" />                
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField ControlStyle-CssClass="campos" HeaderText="Falla">
                <ItemStyle ForeColor="blue" Width="20px" />
                <ControlStyle Width="65px"  />
                <ItemTemplate>                    
                    <asp:TextBox runat="server" ID="falla1" TextMode="Number" />
                    <asp:TextBox runat="server" ID="falla2" TextMode="Number" />
                    <asp:TextBox runat="server" ID="falla3" TextMode="Number" />                
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:LinkButton Text="Grabar" CssClass="btn btn-success" runat="server" ID="grabar" OnClick="grabar_Click" />
     </div>
    </div>

</asp:Content>
