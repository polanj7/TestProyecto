<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrosHormigon.aspx.cs" Inherits="SystemLab.Registros.RegistrosHormigon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .sombra {
            /*box-shadow: 1px 2px 4px #808080;*/ /* Sombra normal */
            /*box-shadow: 5px -5px 0 2px #444;      /* Sombra superior sin desenfoque */
            /*box-shadow: 5px 5px 25px #222 inset;*/ /* Sombra interior */
        }

        .subir {
            background: #f55d3e;
            color: #fff;
        }

            .subir:hover {
                color: #fff;
                background: #f7cb15;
            }
    </style>

    <br />
    <%--    <div class="row">
        <div class="col-md-12 pull-right">
            <div class="col-md-12">                
                <asp:FileUpload runat="server" ID="fileCarga" CssClass="pull-right" onchange="fileinfo()" style="display:none;" />
                <asp:LinkButton Text="Add image" ID="brnSaveImage" CssClass="btn btn-info pull-right" runat="server" OnClick="brnSaveImage_Click" Font-Size="X-Small" >
                    <span class="glyphicon glyphicon-floppy-saved"></span>                
                </asp:LinkButton>
                <asp:LinkButton runat="server" ID="fileButton" CssClass="btn pull-right subir" Width="50" Font-Size="X-Small">
                    <span class="glyphicon glyphicon-paperclip"></span>
                </asp:LinkButton>
            </div>
            <div class="col-md-5">                
                <asp:TextBox runat="server" ID="txtS" Visible="false" />
            </div>
        </div>
    </div>   --%>


    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hdRegistroID" Value="0" />
            <asp:HiddenField runat="server" ID="hdRegistroDetalleID" Value="0" />

            <div class="panel panel-default sombra" style="padding: 0px; margin-bottom: 5px !important">
                <div class="panel-body">

                    <h5 class="text-center" style="color: #ffffff; background-color: #274f74; padding: 5px; margin: 0px 200px 10px 200px;">Proyecto</h5>

                    <div class="row">
                        <div class="col-xs-3">
                            <div class="form-group">
                                <asp:Label Text="Cliente*" runat="server" />
                                <asp:DropDownList runat="server" ID="cliente" CssClass="form-control" OnTextChanged="cliente_TextChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-xs-3">
                            <div class="form-group">
                                <asp:Label Text="Registro*" runat="server" />
                                <div class="input-group">
                                    <span class="input-group-addon" style="background-color: whitesmoke">
                                        <asp:DropDownList runat="server" ID="cboRegistro" Visible="true" AutoPostBack="true" OnTextChanged="cboRegistro_TextChanged">
                                        </asp:DropDownList>
                                    </span>
                                    <asp:TextBox runat="server" ID="registro" CssClass="form-control" OnTextChanged="registro_TextChanged" AutoPostBack="true" />
                                </div>
                            </div>
                        </div>


                        <div class="col-xs-3">
                            <div class="form-group">
                                <asp:Label Text="Proyecto*" runat="server" />
                                <div class="input-group">
                                    <span class="input-group-addon" style="background-color: whitesmoke">
                                        <asp:DropDownList runat="server" ID="cboProyecto" Visible="false" OnTextChanged="cboProyecto_TextChanged" AutoPostBack="true" Width="30px">
                                        </asp:DropDownList>
                                    </span>
                                    <asp:TextBox runat="server" ID="proyecto" CssClass="form-control" OnTextChanged="proyecto_TextChanged" AutoPostBack="true" />
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <div class="form-group">
                                <asp:Label Text="Volumen" runat="server" />
                                <asp:TextBox runat="server" ID="volumen" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3">
                            <div class="form-group">
                                <asp:Label Text="Dirección" runat="server" />
                                <asp:TextBox runat="server" ID="direccion" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <div class="form-group">
                                <asp:Label Text="Elaboración" runat="server" />
                                <asp:DropDownList runat="server" ID="elaboracion" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <div class="form-group">
                                <asp:Label Text="Contacto (email)" runat="server" />
                                <asp:TextBox runat="server" ID="contacto" CssClass="form-control" placeholder="Digite el contacto aquí" />
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <div class="form-group pull-right">
                                <br />
                                <asp:LinkButton Text="" ID="agregar" CssClass="btn btn-sm btn-default" runat="server" OnClick="agregar_Click">
                                     <span class="glyphicon glyphicon-floppy-saved"></span> Guardar Proyecto     
                                </asp:LinkButton>

                                <asp:LinkButton Text="Limpiar" ID="limpiar" CssClass="btn btn-sm btn-default" runat="server" OnClick="limpiar_Click">
                                    <span class="glyphicon glyphicon-trash"></span> Limpiar
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="panel panel-default sombra" style="margin-bottom: 5px;">
                <div class="panel-body">
                    <h5 class="text-center" style="color: #ffffff; background-color: #274f74; padding: 5px; margin: 0px 200px 10px 200px" runat="server" id="lblmodo">Datos</h5>

                    <div class="row">
                        <div class="col-md-4">
                            <h4>
                                <asp:Label Text="" runat="server" ID="lblSubregistroActual" CssClass="label label-warning" /></h4>
                        </div>
                        <div class="col-md-3">
                            <asp:Label Text="" runat="server" ID="lblMensajeSuccess" CssClass="label label-success pull-right" />
                            <asp:Label Text="" runat="server" ID="lblMensajeDanger" CssClass="label label-danger pull-right" />
                        </div>
                    </div>
                    <div class="row">

                        <div style="margin-bottom: 2rem;">
                            <div class="col-xs-4">
                                <div class="form-group">
                                    <asp:Label Text="Sub-Registro*" runat="server" />
                                    <asp:TextBox runat="server" ID="subregistro" CssClass="form-control" OnTextChanged="subregistro_TextChanged" Enabled="false" AutoPostBack="true" />
                                </div>
                            </div>
                            <div class="col-xs-2">
                                <div class="form-group">
                                    <asp:Label Text="Hora Inicial" runat="server" />
                                    <asp:TextBox runat="server" ID="inicial" CssClass="form-control" TextMode="Time" />
                                </div>
                            </div>
                            <div class="col-xs-2">
                                <div class="form-group">
                                    <asp:Label Text="Hora Final" runat="server" />
                                    <asp:TextBox runat="server" ID="final" CssClass="form-control" TextMode="Time" />
                                </div>
                            </div>
                            <div class="col-xs-2">
                                <div class="form-group">
                                    <asp:Label Text="Resistencia kg/cm2" runat="server" />
                                    <asp:TextBox runat="server" ID="resistencia" CssClass="form-control" TextMode="Number" />
                                </div>
                            </div>
                            <div class="col-xs-2">
                                <div class="form-group">
                                    <asp:Label Text="Slump (Pulgadas)" runat="server" />
                                    <asp:TextBox runat="server" ID="slump" CssClass="form-control" TextMode="Number" />
                                </div>
                            </div>
                            <div class="col-xs-3">
                                <div class="form-group">
                                    <asp:Label Text="Temperatura (°C)" runat="server" />
                                    <asp:TextBox runat="server" ID="temperatura" CssClass="form-control" TextMode="Number" />
                                </div>
                            </div>
                            <div class="col-xs-3">
                                <div class="form-group">
                                    <asp:Label Text="Elemento" runat="server" />
                                    <asp:TextBox runat="server" ID="elemento" CssClass="form-control" />
                                    <%--    <div class="input-group">
                                        <span class="input-group-addon" style="background-color: whitesmoke" visible="false">
                                            <asp:DropDownList runat="server" ID="cboElemento" Visible="true" AutoPostBack="true" OnTextChanged="cboElemento_TextChanged" Width="30px">
                                            </asp:DropDownList>
                                        </span>
                                       
                                    </div>--%>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="Sector" runat="server" />
                                    <asp:TextBox runat="server" ID="sector" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="Curado" runat="server" />
                                    <asp:DropDownList runat="server" ID="curado" CssClass="form-control">
                                        <asp:ListItem Text="Obra" Value="Obra" />
                                        <asp:ListItem Text="Laboratorio" Value="Laboratorio" />
                                    </asp:DropDownList>
                                    <%--<asp:TextBox runat="server" ID="curado" CssClass="form-control" />--%>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="Tamaño MAX Agregado" runat="server" />
                                    <asp:DropDownList runat="server" ID="agregado" CssClass="form-control">
                                        <asp:ListItem Text="1''" Value="1" />
                                        <asp:ListItem Text="1 1/2''" Value="1 1/2" />
                                        <asp:ListItem Text="1/2''" Value="1/2" />
                                        <asp:ListItem Text="3/4''" Value="3/4" />
                                        <asp:ListItem Text="3/8''" Value="3/8" />
                                        <asp:ListItem Text="Mortero''" Value="Mortero" />
                                    </asp:DropDownList>
                                    <%--<asp:TextBox runat="server" ID="agregado" CssClass="form-control" />--%>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="Fecha de vaciado" runat="server" />
                                    <asp:TextBox runat="server" ID="vaciado" CssClass="form-control fecha" TextMode="Date" > 
                                        </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label Text="Fecha de entrega" runat="server" />
                                    <asp:TextBox runat="server" ID="entrega" CssClass="form-control" TextMode="Date">
                                     </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-3">

                                <div class="form-group">
                                    <asp:Label Text="Hormigonera" runat="server" />
                                    <asp:TextBox runat="server" ID="hormigonera" CssClass="form-control" />
                                    <%--  <div class="input-group">
                                        <span class="input-group-addon" style="background-color: whitesmoke">
                                            <asp:DropDownList runat="server" ID="cboHormigonera" Visible="true" AutoPostBack="true" OnTextChanged="cboHormigonera_TextChanged" Width="30px">
                                            </asp:DropDownList>
                                        </span>
                                       
                                    </div>--%>
                                </div>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label Text="Conduce" runat="server" />
                                <asp:TextBox runat="server" ID="txtConduceG" CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <div class="form-group">
                                    <asp:Label Text="Cantidad Probetas" runat="server" ForeColor="Green" Font-Bold="true" />
                                    <asp:TextBox runat="server" ID="probetastotal" CssClass="form-control" TextMode="Number" />
                                </div>
                            </div>

                            <div class="col-xs-6">
                                <div class="form-group">
                                    <asp:LinkButton Text="" ID="grabar" CssClass="btn btn-sm btn-success pull-right" runat="server" OnClick="grabar_Click" Style="margin-top: 15px;">
                                            <span class="glyphicon glyphicon-floppy-saved"></span> Guardar Registro
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>

            <div class="panel panel-default sombra">
                <div class="panel-body">

                    <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" OnRowCommand="grvDatos_RowCommand" OnRowDataBound="grvDatos_RowDataBound">

                        <SelectedRowStyle BackColor="#339933" CssClass="label label-danger" />
                        <AlternatingRowStyle BackColor="#e7e9ea" />
                        <RowStyle Font-Size="Smaller" Height="10px" />

                        <HeaderStyle BackColor="#274F74" ForeColor="#e4ecf3" Font-Size="Small" />

                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Bind("id") %>' runat="server" ID="lblID" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="subregistro" HeaderText="Sub Reg" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Vaciado" />
                            <asp:TemplateField HeaderText="Edad Detalle">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblEdad" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="elemento" HeaderText="Elemento" />
                            <asp:BoundField DataField="sector" HeaderText="Sector" />
                            <asp:BoundField DataField="slump" HeaderText="Slump" />
                            <asp:BoundField DataField="temp" HeaderText="Temperatura" />
                            <asp:BoundField DataField="resistencia" HeaderText="Resistencia" />
                            <asp:TemplateField ItemStyle-Width="130px" HeaderText="Acciones" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton Text="" runat="server" CssClass="btn btn-sm btn-default" ID="Editar" ToolTip="Editar" CommandName="editar" CommandArgument='<%# Bind("subregistro") %>'>
                                        <span class="glyphicon glyphicon-edit"></span>      
                                    </asp:LinkButton>
                                    <asp:LinkButton Text="Editar" runat="server" CssClass="btn btn-sm btn-default" ID="Edad" ToolTip="Agregar Edad" CommandName="modal" CommandArgument='<%# Bind("id") %>'>
                                        <span class="glyphicon glyphicon-menu-hamburger"></span>     
                                    </asp:LinkButton>
                                    <asp:LinkButton Text="" runat="server" CssClass="btn btn-sm btn-danger" ID="Eliminar" ToolTip="Eliminar" OnClientClick="return confirm('Desea eliminar el sub-registro?');" CommandName="dell" CommandArgument='<%# Bind("subregistro") %>'>
                                        <span class="glyphicon glyphicon-remove"></span>     
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Label Text="" runat="server" ID="lblMensajeSuccessProyecto" CssClass="label label-success pull-right" />
    <asp:Label Text="" runat="server" ID="lblMensajeDangerproyecto" CssClass="label label-danger pull-right" />


    <asp:UpdatePanel runat="server" ID="updatePanelTop" UpdateMode="Conditional" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="modal fade" id="modalEdad" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Edades por Probetas</h4>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField runat="server" ID="hdEdadID" Value="0" />
                                    <asp:HiddenField runat="server" ID="hdProbetas" Value="0" />

                                    <div class="row">
                                        <div class="col-xs-12" style="margin-bottom: 10px;">
                                            <span style="color: red;">
                                                <asp:CheckBox Text="" runat="server" ID="chkClon" Font-Size="X-Small" Checked="true" />
                                                Clonar edad para todos los Registros
                                            </span>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:Label runat="server" ID="lblProbetasFaltantes" CssClass="label label-info" />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="">Cantidad</label>
                                            <asp:TextBox runat="server" ID="cantidad" CssClass="form-control" TextMode="Number" Enabled="false" />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="">Dias</label>
                                            <asp:TextBox runat="server" ID="dias" CssClass="form-control" TextMode="Number" Enabled="false" />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="">Dimensión</label>
                                            <asp:DropDownList runat="server" ID="dimension" CssClass="form-control" Enabled="false">
                                                <asp:ListItem Text="10x20" Value="10x20" />
                                                <asp:ListItem Text="15x30" Value="15x30" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="">Conduce</label>
                                            <asp:TextBox runat="server" ID="conduce" CssClass="form-control" Enabled="false" />
                                        </div>

                                        <div class="col-xs-12" style="margin: 5px 0px 5px 0px">
                                            <asp:LinkButton Text="" runat="server" CssClass="btn btn-sm btn-default pull-right" ID="add" OnClick="add_Click" Enabled="true" ToolTip="Agregra">
                                         <span class="glyphicon glyphicon-floppy-saved"></span> Guardar
                                            </asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xs-12">

                                            <asp:GridView runat="server" ID="grvEdades" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" Font-Size="Small" OnRowCommand="grvEdades_RowCommand">
                                                <HeaderStyle BackColor="#274F74" ForeColor="#e4ecf3" />
                                                <SelectedRowStyle BackColor="#339933" CssClass="label label-danger" />
                                                <AlternatingRowStyle BackColor="#e7e9ea" />
                                                <RowStyle Font-Size="Smaller" Height="10px" />
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%# Bind("ID") %>' runat="server" ID="lblID" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Desc" HeaderText="Detalle" />
                                                    <asp:TemplateField ItemStyle-Width="130px" HeaderText="Acciones" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton Text="" runat="server" CssClass="btn btn-sm btn-default" ID="Editar" ToolTip="Editar" CommandName="editar" CommandArgument='<%# Bind("ID") %>'>
                                                        <span class="glyphicon glyphicon-edit"></span>      
                                                            </asp:LinkButton>
                                                            <asp:LinkButton Text="" runat="server" CssClass="btn btn-sm btn-danger" ID="Eliminar" ToolTip="Eliminar" OnClientClick="return confirm('Desea eliminar la edad?');" CommandName="delete" CommandArgument='<%# Bind("ID") %>'>
                                                        <span class="glyphicon glyphicon-remove"></span>     
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"></ajaxToolkit:CalendarExtender>--%>

    <script type="text/javascript">


        function modalEdad() {
            $('#modalEdad').modal({ show: true });
        };






    </script>

    <script>
        function fileinfo() {
            //txtS.ClientID ""
            document.getElementById('<%= "" %>').value = document.getElementById('<%= "" %>').value;
        }


    </script>



</asp:Content>
