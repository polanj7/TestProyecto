<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrosHormigon.aspx.cs" Inherits="SystemLab.Registros.RegistrosHormigon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style type="text/css">
        .sombra {
            box-shadow: 1px 2px 4px #808080; /* Sombra normal */
            /*box-shadow: 5px -5px 0 2px #444;      /* Sombra superior sin desenfoque */
            /*box-shadow: 5px 5px 25px #222 inset;*/ /* Sombra interior */
        }
    </style>

    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hdRegistroID" Value="0" />
            <asp:HiddenField runat="server" ID="hdRegistroDetalleID" Value="0" />

            <asp:GridView  runat="server" ID="idl" ></asp:GridView>

            <div class="panel panel-default sombra" style="padding: 0px;">
                <div class="panel-body">
                    <div class="row" style="margin-bottom: 2rem;">
                        <div class="col-md-12">
                            <h4 style="color: #9eb2ca">Registro acompañamiento</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:Label Text="Registro*" runat="server" />
                                <asp:TextBox runat="server" ID="registro" CssClass="form-control" OnTextChanged="registro_TextChanged" AutoPostBack="true" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label Text="Cliente*" runat="server" />
                                <asp:DropDownList runat="server" ID="cliente" CssClass="form-control">                                   
                                </asp:DropDownList>
                                <%--<asp:TextBox runat="server" ID="cliente" CssClass="form-control" />--%>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label Text="Proyecto*" runat="server" />
                                <asp:TextBox runat="server" ID="proyecto" CssClass="form-control" />
                            </div>
                        </div>
                        
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label Text="Volumen" runat="server" />
                                <asp:TextBox runat="server" ID="volumen" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label Text="Dirección" runat="server" />
                                <asp:TextBox runat="server" ID="direccion" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <br />
                                <asp:LinkButton Text="Agregar" ID="agregar" CssClass="btn btn-info" runat="server" OnClick="agregar_Click" />
                                -
                        <asp:LinkButton Text="Limpiar" ID="limpiar" CssClass="btn btn-danger" runat="server" OnClick="limpiar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="panel-default sombra">
                <div class="panel-body">

                    <div class="row" style="margin-bottom: 2rem;">
                        <div class="col-md-6">
                            <h4 style="color: #9eb2ca">
                                <asp:Label Text="Datos" runat="server" ID="lblmodo" /></h4>
                        </div>
                    </div>
                    <div class="row">


                        <div class="col-md-9">
                            <div class="row" style="margin-bottom: 2rem;">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Sub-Registro" runat="server" />
                                        <asp:TextBox runat="server" ID="subregistro" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Hora Inicial" runat="server" />
                                        <asp:TextBox runat="server" ID="inicial" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Hora Final" runat="server" />
                                        <asp:TextBox runat="server" ID="final" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Resistencia kg/cm2" runat="server" />
                                        <asp:TextBox runat="server" ID="resistencia" CssClass="form-control" TextMode="Number"  />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Slump (Pulgadas)" runat="server" />
                                        <asp:TextBox runat="server" ID="slump" CssClass="form-control" TextMode="Number" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Temperatura (°C)" runat="server" />
                                        <asp:TextBox runat="server" ID="temperatura" CssClass="form-control" TextMode="Number" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Elemento" runat="server" />
                                        <asp:TextBox runat="server" ID="elemento" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label Text="Sector" runat="server" />
                                        <asp:TextBox runat="server" ID="sector" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Label Text="Elaboración" runat="server" />
                                        <asp:DropDownList runat="server" ID="elaboracion" CssClass="form-control">                                   
                                        </asp:DropDownList>                                       
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Label Text="Curado" runat="server" />
                                        <asp:DropDownList runat="server" ID="curado" CssClass="form-control">
                                            <asp:ListItem Text="Obra" Value="Obra"/>
                                            <asp:ListItem Text="Laboratorio" Value="Laboratorio" />
                                        </asp:DropDownList>
                                        <%--<asp:TextBox runat="server" ID="curado" CssClass="form-control" />--%>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Label Text="Tamaño MAX Agregado" runat="server" />
                                           <asp:DropDownList runat="server" ID="agregado" CssClass="form-control">
                                            <asp:ListItem Text="1''" Value="1" />
                                            <asp:ListItem Text="1 1/2''"  Value="1 1/2" />
                                            <asp:ListItem Text="1/2''"  Value="1/2" />
                                            <asp:ListItem Text="3/4''"  Value="3/4" />
                                            <asp:ListItem Text="3/8''"  Value="3/8" />
                                            <asp:ListItem Text="Mortero''"  Value="Mortero" />
                                         </asp:DropDownList>
                                        <%--<asp:TextBox runat="server" ID="agregado" CssClass="form-control" />--%>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de vaciado" runat="server" />
                                        <asp:TextBox runat="server" ID="vaciado" CssClass="form-control" TextMode="Date" />
                                    </div>
                                </div>
                        
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Label Text="Fecha de entrega" runat="server" />
                                        <asp:TextBox runat="server" ID="entrega" CssClass="form-control" TextMode="Date" />
                                    </div>
                                </div>                         
                                        <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Label Text="Hormigonera" runat="server" />
                                        <asp:TextBox runat="server" ID="hormigonera" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <br />
                                        <asp:LinkButton Text="Grabar" ID="grabar" CssClass="btn btn-success" runat="server" OnClick="grabar_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="panel panel-primary">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <label for="">Probetas totales</label>
                                            <asp:TextBox runat="server" ID="probetastotal" CssClass="form-control" TextMode="Number" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label for="">Dias</label>
                                            <asp:TextBox runat="server" ID="dias" CssClass="form-control" TextMode="Number" />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="">Cantidad</label>
                                            <asp:TextBox runat="server" ID="cantidad" CssClass="form-control" TextMode="Number" />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="">Dimensión</label>
                                            <asp:DropDownList runat="server" ID="dimension" CssClass="form-control">
                                                <asp:ListItem Text="10x20" Value="10x20" />
                                                <asp:ListItem Text="15x30" Value="15x30" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="">Condude</label>
                                            <asp:TextBox runat="server" ID="conduce" CssClass="form-control" />
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <asp:LinkButton Text="Add" runat="server" CssClass="btn btn-primary" ID="add" OnClick="add_Click" Width="100%" />
                                        </div>

                                        <div class="col-md-12">    
                                            <asp:ListView runat="server" ID="w">
                                                <ItemTemplate>
                                                    <asp:Label Text="text" runat="server" />
                                                </ItemTemplate>
                                            </asp:ListView>
                                            <asp:CheckBoxList runat="server" ID="lista" Font-Size="10px" OnSelectedIndexChanged="lista_SelectedIndexChanged"  AutoPostBack="true"  >

                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>      
            <div class="panel panel-default sombra">
                <div class="panel-body">

                    <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="grvDatos_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="subregistro" HeaderText="Sub Reg" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Vaciado" />
                            <asp:BoundField DataField="edad" HeaderText="Edad Detalle" />
                            <asp:BoundField DataField="elemento" HeaderText="Elemento" />
                            <asp:BoundField DataField="sector" HeaderText="Sector" />
                            <asp:BoundField DataField="slump" HeaderText="Slump" />
                            <asp:BoundField DataField="temp" HeaderText="Temperatura" />
                            <asp:BoundField DataField="resistencia" HeaderText="Resistencia" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Editar" runat="server" CssClass="btn btn-warning" ID="Editar" CommandName="editar" CommandArgument='<%# Bind("subregistro") %>' /> - 
                                    <asp:LinkButton Text="Eliminar" runat="server" CssClass="btn btn-danger" ID="Eliminar" CommandName="delete" CommandArgument='<%# Bind("subregistro") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>



    <div id="myModal" class="modal" tabindex="-1" role="dialog" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edades de rompimiento</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="modal-footer">
                        <%--<asp:LinkButton Text="Save changes" runat="server" CssClass="btn btn-primary" ID="save" OnClick="save_Click" />--%>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
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
