<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="SystemLab.Mantenimiento.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-primary">
        <div class="panel-heading">Mantenimiento de Tecnicos</div>
        <div class="panel-body">

            <div class="row">

                <div class="col-md-12">
                    <asp:Label Text="" runat="server" ID="lblMesnajeDanger" CssClass="label label-" />
                </div>

                <div class="col-md-3">
                    <asp:Label Text="Tecnico" runat="server" />
                    <asp:TextBox runat="server" ID="txtTecn" CssClass="form-control" />
                </div>
                <div class="col-md-2">
                    <br />
                    <asp:Button Text="Agregar" runat="server" CssClass="btn btn-primary pull-right" ID="btnAddT" OnClick="btnAddT_Click" />
                </div>
            </div>

            <div class="row">
                <br />
                <div class="col-md-5">
                    <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" OnRowCommand="grvDatos_RowCommand">
                        <HeaderStyle BackColor="#000" ForeColor="#ffffff" />
                        <Columns>                            
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Tecnico" />                          
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Editar" runat="server" CssClass="btn btn-warning" ID="Editar" CommandName="editar" CommandArgument='<%# Bind("ResponsablesID") %>' />
                                     - 
                                    <asp:LinkButton Text="Eliminar" runat="server" CssClass="btn btn-danger" ID="Eliminar" CommandName="delete" CommandArgument='<%# Bind("ResponsablesID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>            

        </div>
    </div>

</asp:Content>
