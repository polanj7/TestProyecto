<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnviosEnsayos.aspx.cs" Inherits="SystemLab.Registros.EnviosEnsayos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <script>
        $(this).ready(function () {

            $('#MainContent_cboCliente').change(function () {
                
            });

        });
    </script>

    <br />

    <div class="panel panel-default">
        <div class="panel-body">
            <h4 style="color: dimgray; text-align: center; margin-bottom: 15px;">Historial de Registros</h4>
            <hr />
            <asp:Label Text="" CssClass="label label-success" runat="server" ID="lblSuccess" />
            <asp:Label Text="" CssClass="label label-danger" runat="server" ID="lblDanger" />

            <div class="row">
                <div class="col-xs-3">
                    <asp:Label Text="Cliente" runat="server" />
                    <asp:DropDownList runat="server" ID="cboCliente" CssClass="form-control js-example-basic-single">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-3">
                    <asp:Label Text="Proyecto" runat="server" />
                    <asp:DropDownList runat="server" ID="cboProyecto" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label Text="Registro" runat="server" />
                    <asp:TextBox runat="server" ID="txtRegistro" CssClass="form-control" placeholder="Escriba aqui..." />
                </div>
                <div class="col-md-3">
                    <br />
                    <asp:LinkButton runat="server" ID="btnbuscar" CssClass="btn btn-info" OnClick="btnbuscar_Click" ToolTip="Click para bucar">
                    <span class="glyphicon glyphicon-search"></span>
                    </asp:LinkButton>
                </div>
            </div>

            <br />
            <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnRowDataBound="grvDatos_RowDataBound" OnRowCommand="grvDatos_RowCommand" Font-Size="Smaller">
                <RowStyle Font-Size="Small" />
                <HeaderStyle BackColor="#274F74" ForeColor="#e4ecf3" />
                <EmptyDataTemplate>
                    <h4>No se encontraron registros!</h4>
                </EmptyDataTemplate>
                <EmptyDataRowStyle BackColor="White" ForeColor="red" HorizontalAlign="Center" Font-Size="Small" />
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="10px" BackColor="#ffffff" />
                        <ItemTemplate>                            
                            <img alt="" style="cursor: pointer; width:20px; height:20px;" src="../Images/plus.png" />
                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                <asp:GridView runat="server" ID="grvDatos2" CssClass="table table-bordered" AutoGenerateColumns="false" Font-Size="Smaller" OnRowDataBound="grvDatos2_RowDataBound" BackColor="#ffffff">
                                    <RowStyle Font-Size="Small" />
                                     <HeaderStyle BackColor="#274F74" ForeColor="#e4ecf3" />
                                    <EmptyDataRowStyle BackColor="#6d0e1e" ForeColor="Window" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20px" />
                                            <ItemTemplate>
                                                <img alt="" style="cursor: pointer; width:20px; height:20px;" src="../Images/plus.png" />                                               
                                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                    <asp:GridView runat="server" ID="grvDatos3" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="grvDatos3_RowDataBound">
                                                        <RowStyle Font-Size="Larger" />
                                                         <HeaderStyle BackColor="#274F74" ForeColor="#e4ecf3" />
                                                        <EmptyDataRowStyle BackColor="#6d0e1e" ForeColor="Window" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label Text='<%# Bind("Id") %>' runat="server" ID="lblId" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Dimensión">
                                                                <ItemTemplate>
                                                                    <asp:Label Text='<%# Bind("dimension") %>' runat="server" ID="lblD" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Carga" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label Text='<%# Bind("carga") %>' runat="server" ID="lblC" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Edad" DataField="dias" />
                                                            <asp:TemplateField HeaderText="Cargas individuales">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblCargasInd" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Resistencia individual">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblResInd" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Promedio Resistencia">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblR" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="% Resistencia">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblRP" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                        <asp:BoundField HeaderText="Resistencia kg/cm2" DataField="resistencia" Visible="true" />
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
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label Text='<%# Bind("Id")%>' runat="server" ID="lblID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" Visible="false" />
                    <asp:TemplateField Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton Text="text" runat="server" ID="verFile" CommandName="verFile" CommandArgument='<%# Bind("Id") %>'>
                                <span class="glyphicon glyphicon-paperclip"></span>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="8%" ControlStyle-Width="10px" HeaderText="Registro" DataField="registro" />
                    <asp:BoundField ItemStyle-Width="50%" HeaderText="Proyecto" DataField="proyecto" />
                    <asp:BoundField ItemStyle-Width="10%" HeaderText="Ultimo Correo" DataField="FUEmasCG" />
                    <asp:BoundField ItemStyle-Width="15%" HeaderText="Cliente" DataField="cliente" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemStyle Width="110px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%--<input type="text" name="name" value='<%= Bind("Id") %>' />--%>
                              <asp:LinkButton Text="Enviar" runat="server" ID="descarga" CssClass="btn btn-sm btn-default" CommandName="download" CommandArgument='<%# Bind("Id") %>' Width="40px" ToolTip="Descargar Documento">
                                <span class="glyphicon glyphicon-download text-danger"></span>
                            </asp:LinkButton>
                            <asp:LinkButton Text="Enviar" runat="server" ID="enviar" CssClass="btn btn-sm btn-default" CommandName="send" CommandArgument='<%# Bind("Id") %>' Width="40px" ToolTip="Enviar Notificación">
                                <span class="glyphicon glyphicon-envelope text-danger"></span>
                            </asp:LinkButton>                          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>


    <asp:UpdatePanel runat="server" ID="updatePanelTop" UpdateMode="Conditional" ChildrenAsTriggers="True">
        <Triggers>
            <asp:PostBackTrigger ControlID="envio" />
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="modalEmail" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h5 class="modal-title"><span class="glyphicon glyphicon-envelope" style="color: darkblue;"></span> Envíos de Correos</h5>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField runat="server" ID="hdEdadID" Value="0" />
                                    <asp:HiddenField runat="server" ID="hdProbetas" Value="0" />

                                    <div class="row">
                                        <div class="col-xs-12">
                                            <asp:Label Text="Emails" runat="server" />
                                            <asp:TextBox runat="server" ID="contacto" placeholder="Contacto(correo)" CssClass="form-control" />
                                        </div>

                                        <div class="col-xs-12">
                                            <br />
                                            <%--   <label class="file-upload"><span class="glyphicon glyphicon-file"> Cargar Documento</span>
                                                 <asp:FileUpload runat="server" multiple="true" accept=".pdf" ID="cargaPDF" OnUnload="cargaPDF_Unload" />
                                            </label>--%>
                                            <asp:FileUpload ID="cargaPDF" runat="server" multiple="true" accept=".pdf" text="OK" />
                                            <asp:Label Text="" runat="server" ID="lblCarga" />
                                        </div>

                                        <div class="col-xs-12" style="margin: 5px 0px 5px 0px">
                                            <asp:LinkButton Text="" runat="server" CssClass="btn btn-sm btn-default pull-right" ID="envio" OnClick="envio_Click" Enabled="true" ToolTip="Envia Email">
                                                 <span class="glyphicon glyphicon-floppy-saved"></span> Enviar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>

        <script type="text/javascript">
        function modalEmail() {
            $('#modalEmail').modal({ show: true });
        };


        function ReporteWeb() {
            var sURL = 'http://localhost:4201/reporteWebFichaTecnica.aspx';
            console.log(5);
            var oHiddFrame = document.createElement("iframe");
            oHiddFrame.onload = setPrint;
            oHiddFrame.style.visibility = "hidden";
            oHiddFrame.style.position = "fixed";
            oHiddFrame.style.right = "0";
            oHiddFrame.style.bottom = "0";
            oHiddFrame.src = sURL;
            document.body.appendChild(oHiddFrame);
        };

        function setPrint() {

            this.contentWindow._container_ = this;
            this.contentWindow.onbeforeunload = closePrint;
            this.contentWindow.onafterprint = closePrint;
            this.contentWindow.focus(); // Required for IE
            this.contentWindow.print();
        };

        function closePrint() {
            document.body.removeChild(this._container_);
        };


    </script>

    <script type="text/javascript">

        $(document).on("click", "[src*=plus]", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Images/minus.png");
        });

        $(document).on("click", "[src*=minus]", function () {
            $(this).attr("src", "../Images/plus.png");
            $(this).closest("tr").next().remove();
        });

        //$("[src*=plus]").on("click", function () {
        //    $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        //    $(this).attr("src", "../Images/minus.png");
        //});

        //$("[src*=minus]").on("click", function () {
        //    $(this).attr("src", "../Images/plus.png");
        //    $(this).closest("tr").next().remove();
        //});



    </script>
    <style>
        .file-upload {
            display: inline-block;
            overflow: hidden;
            text-align: center;
            vertical-align: middle;
            font-family: Arial;
            border: 1px solid #124d77;
            background: #061522;
            color: #fff;
            border-radius: 6px;
            -moz-border-radius: 6px;
            cursor: pointer;
            text-shadow: #000 1px 1px 2px;
            -webkit-border-radius: 6px;
        }

            .file-upload:hover {
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #0061a7), color-stop(1, #007dc1));
                background: -moz-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -webkit-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -o-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: linear-gradient(to bottom, #0061a7 5%, #007dc1 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#0061a7', endColorstr='#007dc1',GradientType=0);
                background-color: #0061a7;
            }

        /* The button size */
        .file-upload {
            height: 30px;
            width: 100%;
        }


            .file-upload input {
                top: 0;
                left: 0;
                margin: 0;
                font-size: 11px;
                font-weight: bold;
                /* Loses tab index in webkit if width is set to 0 */
                opacity: 0;
                filter: alpha(opacity=0);
            }
    </style>

</asp:Content>
