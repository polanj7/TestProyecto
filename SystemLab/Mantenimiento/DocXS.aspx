<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocXS.aspx.cs" Inherits="SystemLab.Mantenimiento.DocXS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <br />
                    

    <div class="panel panel-default">
        <div class="panel-heading">             
            <h4>Control de Evidencias</h4>
        </div>
        
        <div class="panel-body">
            <asp:Label Text="" CssClass="label label-success" runat="server" ID="lblSuccess" />
           <asp:Label Text="" CssClass="label label-danger" runat="server" ID="lblDanger" />
           

            <div class="row">
                 <br />
                <div class="col-md-3">
                    <asp:Label Text="Cliente" runat="server" />
                    <asp:DropDownList runat="server" ID="cboCliente" CssClass="form-control">                   
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label Text="Proyecto" runat="server" />
                     <asp:DropDownList runat="server" ID="cboProyecto" CssClass="form-control">                   
                    </asp:DropDownList>
                </div>
                <div class="col-md-3"> 
                    <asp:Label Text="Registro" runat="server" />
                    <asp:TextBox runat="server" ID="txtRegistro" CssClass="form-control" placeholder="Escriba aqui..."/>
                </div>
                        <div class="col-md-3"> 
                            <br />
                <asp:LinkButton runat="server" ID="btnbuscar" CssClass="btn btn-info" OnClick="btnbuscar_Click" ToolTip="Filtrar Historico" >
                     <span class="glyphicon glyphicon-search"></span>
                </asp:LinkButton>
               <asp:LinkButton runat="server" ID="btnVolver" CssClass="btn btn-warning" OnClick="btnVolver_Click" ToolTip="Volver a Historico" >
                    <span class="glyphicon glyphicon-menu-right"></span>
               </asp:LinkButton>
            </div>
            </div>
    
            <br />
            <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered" AutoGenerateColumns="false" Font-Size="Smaller" AlternatingRowStyle-BorderColor="YellowGreen">
                <RowStyle Font-Size="Larger" />
                <HeaderStyle BackColor="#53ABC8" ForeColor="#e4ecf3" />
                <EmptyDataTemplate>
                    <h4>No se encontraron registros!</h4>
                </EmptyDataTemplate>
                <EmptyDataRowStyle BackColor="#6d0e1e" ForeColor="Window" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField  Visible="false">                      
                        <ItemTemplate>
                            <asp:Label Text='<%# Bind("Id")%>' runat="server" ID="lblID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" Visible="false" />
                    <asp:TemplateField Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton Text="text" runat="server" ID="verFile" OnClick="verFile_Click">
                                <span class="glyphicon glyphicon-paperclip"></span>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="13%" ControlStyle-Width="10px" HeaderText="Registro" DataField="registro" />
                    <asp:BoundField ItemStyle-Width="70%" HeaderText="Proyecto" DataField="proyecto" />
                    <asp:BoundField ItemStyle-Width="15%" HeaderText="Cliente" DataField="cliente" />
                </Columns>
            </asp:GridView>
        </div>
    </div>


    <div id="myModal" class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:DataList ID="dlData" runat="server" RepeatColumns="1" CellSpacing="4" RepeatLayout="Table" CssClass="table table-borderless" BackColor="#cccccc">
                        <ItemTemplate>
                            <table class="tables table table-hover" id="tbl" runat="server">
                                <tr>
                                    <td>
                                        <asp:Image ImageUrl='<%# Eval("rutaMMG")%>' runat="server" Width="100%" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>

            </div>
        </div>
    </div>

    <script type="text/javascript">
        function modalShow() {
            $('#myModal').modal();
        };
    </script>


</asp:Content>
