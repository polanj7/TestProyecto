<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="SystemLab.Client.Clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
     <br />
    <div class="row">
        <div class="col-md-12">


            <asp:HiddenField runat="server" ID="hdTipo" />
            <asp:HiddenField runat="server" ID="hdClientID" Value="0" />

            <div class="panel panel-primary">
                <div class="panel panel-heading">Mantenimiento de Clientes</div>
                <div class="panel-body">
                    <asp:LinkButton Text="Nuevo Cliente" runat="server" ID="new" CssClass="btn btn-primary pull-right" OnClick="new_Click" />
                    <asp:GridView runat="server" ID="gDatos" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="RowCommand">
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        <Columns>
                            <%-- <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label Text='<%# Bind("ClientID") %>' ID="id" runat="server" />
                        </ItemTemplate>--%>
                            <%--</asp:TemplateField>--%>
                            <asp:BoundField DataField="name" HeaderText="Cliente" />
                            <asp:BoundField DataField="rnc" HeaderText="RNC" />
                            <asp:BoundField DataField="contacts" HeaderText="Contactos" />
                            <asp:BoundField DataField="emails" HeaderText="Emails" />
                            <asp:BoundField DataField="address" HeaderText="Dirección" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Editar" runat="server" CssClass="btn btn-warning" ID="Editar" CommandName="editar" CommandArgument='<%# Bind("ClientID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>



    <div id="myModal" class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Datos del Cliente</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <div class="col-md-8">
                            <label for="">Cliente</label>
                            <asp:TextBox runat="server" ID="name" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label for="">RNC</label>
                            <asp:TextBox runat="server" ID="rnc" CssClass="form-control" />
                        </div>
                        <div class="col-md-12">
                            <label for="">Correos</label>
                            <asp:TextBox runat="server" ID="emails" CssClass="form-control" />
                        </div>
                        <div class="col-md-12">
                            <label for="">Contactos</label>
                            <asp:TextBox runat="server" ID="contacts" CssClass="form-control" />
                        </div>
                        <div class="col-md-12">
                            <label for="">Direccion</label>
                            <asp:TextBox runat="server" ID="address" CssClass="form-control" />
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                     <asp:LinkButton Text="Guardar" runat="server" CssClass="btn btn-primary" ID="save" OnClick="save_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

 



    <script type="text/javascript">

        function modalShow()
        {
            $('#myModal').modal();
        };

        
    </script>

</asp:Content>
