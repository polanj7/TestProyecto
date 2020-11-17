<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnviosEnsayos.aspx.cs" Inherits="SystemLab.Registros.EnviosEnsayos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Historico de registros</h4>
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
                    <asp:TextBox runat="server" ID="txtRegistro" CssClass="form-control"/>
                </div>
                        <div class="col-md-3"> 
                            <br />
                <asp:LinkButton Text="Buscar" runat="server" ID="btnbuscar" CssClass="btn btn-primary" OnClick="btnbuscar_Click" />
            </div>
            </div>
    
            <br />
            <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="grvDatos_RowDataBound" OnRowCommand="grvDatos_RowCommand" Font-Size="Smaller" AlternatingRowStyle-BorderColor="YellowGreen">
                <RowStyle Font-Size="Larger" />
                <HeaderStyle BackColor="#53ABC8" ForeColor="#e4ecf3" />
                <EmptyDataTemplate>
                    <h4>No se encontraron registros!</h4>
                </EmptyDataTemplate>
                <EmptyDataRowStyle BackColor="#6d0e1e" ForeColor="Window" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="30px" />
                        <ItemTemplate>
                            <img alt="" style="cursor: pointer" src="../Images/plus.png" width="20" />
                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                <asp:GridView runat="server" ID="grvDatos2" CssClass="table table-bordered" AutoGenerateColumns="false" Font-Size="Smaller" OnRowDataBound="grvDatos2_RowDataBound" OnRowCommand="grvDatos2_RowCommand" BackColor="#dddddd">
                                    <RowStyle Font-Size="Larger" />
                                    <HeaderStyle BackColor="#53ABC8" ForeColor="#e4ecf3" />
                                    
                                    <EmptyDataRowStyle BackColor="#6d0e1e" ForeColor="Window" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="30px" />
                                            <ItemTemplate>
                                                <img alt="" style="cursor: pointer" src="../Images/plus.png" width="20" />
                                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                    <asp:GridView runat="server" ID="grvDatos3" CssClass="table table-bordered" AutoGenerateColumns="false" Font-Size="Smaller">
                                                        <RowStyle Font-Size="Larger" />
                                                        <HeaderStyle BackColor="#53ABC8" ForeColor="#e4ecf3" />
                                                        <EmptyDataRowStyle BackColor="#6d0e1e" ForeColor="Window" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" Visible="false" />
                                                            <asp:BoundField HeaderText="Dimensión" DataField="dimension" />
                                                            <asp:BoundField HeaderText="Dias" DataField="dias" />
                                                            <asp:BoundField HeaderText="Probetas" DataField="probetas" />
                                                            <asp:BoundField HeaderText="Conduce" DataField="conduce" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Bind("Id")%>' runat="server" ID="lblID" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Sub-Registro" DataField="subregistro" />
                                        <asp:BoundField HeaderText="Resistencia kg/cm2" DataField="resistencia" />
                                        <asp:BoundField HeaderText="Elemento" DataField="elemento" />
                                        <asp:BoundField HeaderText="Sector" DataField="sector" />
                                        <asp:BoundField HeaderText="Fecha Vaciado" DataField="vaciado" />
                                        <%--<asp:TemplateField>
                                            <ItemStyle Width="80px" />
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Enviar" runat="server" ID="enviar2" CssClass="btn btn-success" CommandName="send" CommandArgument='<%# Bind("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  Visible="false">                      
                        <ItemTemplate>
                            <asp:Label Text='<%# Bind("Id")%>' runat="server" ID="lblID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" Visible="false" />
                    <asp:BoundField ItemStyle-Width="10%" ControlStyle-Width="10px" HeaderText="Registro" DataField="registro" />
                    <asp:BoundField ItemStyle-Width="55%" HeaderText="Proyecto" DataField="proyecto" />
                    <asp:BoundField ItemStyle-Width="15%" HeaderText="Cliente" DataField="cliente" />
                    <asp:TemplateField>
                        <ItemStyle Width="20%" />
                        <ItemTemplate>
                            <asp:LinkButton Text="Generar PDF" runat="server" ID="btnPDF" CssClass="btn btn-warning" CommandName="generate" CommandArgument='<%# Bind("Id") %>' OnClick="btnPDF_Click" />
                            <asp:LinkButton Text="Enviar" runat="server" ID="enviar" CssClass="btn btn-success" CommandName="send" CommandArgument='<%# Bind("Id") %>' OnClick="enviar_Click" />                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">

        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../Images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../../Images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>

</asp:Content>
