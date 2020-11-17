<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SystemLab._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <br />
    <br />

    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-8">
                    <h4 style="color: dimgray; font-size: 2rem;">Roturas del dia</h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="filtroDate" />
                </div>
                <div class="col-md-1">
                    <asp:LinkButton Text="Buscar" runat="server" ID="buscar" CssClass="btn btn-default" Width="100%" OnClick="buscar_Click" />
                </div>
            </div>
            <br />

            <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered" AutoGenerateColumns="false">
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

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
