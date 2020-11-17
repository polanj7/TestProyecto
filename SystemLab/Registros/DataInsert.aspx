<%@ Page Title="Ensayo de datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataInsert.aspx.cs" Inherits="SystemLab.Registros.DataInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" data-plus-as-tab="true">


    <style type="text/css">
        .campos {
            margin: 3px;
            border-color: red;
            border: solid 1px;
        }

        .txt {
            padding: 1px;
            font-size: 15px;
        }
        .cajasTab{
            padding:5px;
            font-size: 12px;
            /*background-color: #713a3a*/
        }

    </style>



    <br />

    <div class="panel panel-default">
        <div class="panel-body">
            <h4 style="color: dimgray; text-align: center; margin-bottom: 15px;">Ensayo de resistencia a Compresión en pruebas de cilindros de Hormigón</h4>
            <hr />
            <div class="row">
                <div class="col-xs-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtRegistro" placeholder="Escriba el No. de Registro aqui..." />
                </div>
                <div class="col-xs-2">
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="filtroDate" OnTextChanged="filtroDate_TextChanged" />
                </div>
                <div class="col-xs-1">
                    <asp:LinkButton Text="Buscar" runat="server" ID="buscar" CssClass="btn btn-default" Width="60px" OnClick="buscar_Click">
                        <span class="glyphicon glyphicon-search"></span>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="table-responsive" style="margin-top: 10px;">
                <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="grvDatos_RowDataBound">
                    <RowStyle Font-Size="Small" />
                    <HeaderStyle BackColor="#274F74" ForeColor="#e4ecf3" Font-Size="Small" />
                    <EmptyDataTemplate>
                        <h4>No hay pruebas para esta fecha!</h4>
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle BackColor="White" ForeColor="red" HorizontalAlign="Center" Font-Size="Small" />
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
                        <asp:BoundField DataField="FechaString" HeaderText="Fecha Toma" ItemStyle-Width="100px" />
                        <asp:TemplateField HeaderText="Edad">
                            <ItemTemplate>
                                <asp:Label Text='<%# Bind("Dias") %>' runat="server" ID="lblDias" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Probetas" Visible="false">
                            <ItemTemplate>
                                <asp:Label Text='<%# Bind("CantidadProbetas") %>' runat="server" ID="lblProbetas" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EdadActual" HeaderText="Edad actual" />
                        <asp:BoundField DataField="Probetas" HeaderText="Total Probetas" />
                        <asp:TemplateField ControlStyle-CssClass="campos cajasTab" HeaderText="Peso(kg)">
                            <ItemStyle ForeColor="" Width="20px" />
                            <ControlStyle Width="65px" ForeColor="#003399" Font-Bold="true" Font-Italic="true" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEnsayoDetalle1" Visible="false" />
                                <asp:Label runat="server" ID="lblEnsayoDetalle2" Visible="false" />
                                <asp:Label runat="server" ID="lblEnsayoDetalle3" Visible="false" />
                                <asp:TextBox runat="server" ID="peso1" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                                <asp:TextBox runat="server" ID="peso2" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                                <asp:TextBox runat="server" ID="peso3" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="campos cajasTab" HeaderText="Carga(kg)">
                            <ItemStyle ForeColor="" Width="20px" />
                            <ControlStyle Width="100px" ForeColor="#003399" Font-Bold="true" Font-Italic="true" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="carga1" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                                <asp:TextBox runat="server" ID="carga2" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                                <asp:TextBox runat="server" ID="carga3" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="campos cajasTab" HeaderText="Falla">
                            <ItemStyle ForeColor="" Width="20px" />
                            <ControlStyle Width="65px" ForeColor="#003399" Font-Bold="true" Font-Italic="true" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="falla1" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                                <asp:TextBox runat="server" ID="falla2" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                                <asp:TextBox runat="server" ID="falla3" TextMode="Number" CssClass="cajasTab" onkeydown="EnterToTab()" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:LinkButton Text="" CssClass="btn btn-sm btn-default pull-right" runat="server" ID="grabar" OnClick="grabar_Click">
                 <span class="glyphicon glyphicon-floppy-saved"> Guardar</span>
            </asp:LinkButton>
        </div>
    </div>

    <script type="text/javascript">

        function EnterToTab() {            
            if (event.keyCode == 13) {                

            }   

          
        }

        $(document).ready(function () {
            var inputs = $('.campos:enabled').keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    var nextInput = inputs.get(inputs.index(this) + 1);
                    if (nextInput) {
                        nextInput.focus();
                    }
                }
            });
           
        });
       
    </script>

</asp:Content>
