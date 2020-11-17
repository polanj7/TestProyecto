<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SystemLab._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />   

    <div class="panel panel-default">
        <div class="panel-body">
            <h4 style="color: dimgray; text-align: center; margin-bottom: 15px;">Roturas del dia</h4>
            <hr />
            <div class="row" style="color:#989898">
                <div class="col-xs-4">
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="filtroDate" />
                </div>
                <div class="col-xs-8">
                    <asp:LinkButton Text="Buscar" runat="server" ID="buscar" CssClass="btn btn-default" OnClick="buscar_Click" ToolTip="Click para bucar" Width="60px">
                         <span class="glyphicon glyphicon-search"></span>
                    </asp:LinkButton>
                    <asp:LinkButton Text="Buscar" runat="server" ID="print" CssClass="btn btn-default" ToolTip="Click para imprimir" OnClick="print_Click" Width="60px">
                         <span class="glyphicon glyphicon-file"></span>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="table-responsive" style="margin-top: 10px;">
                <asp:GridView runat="server" ID="grvDatos" CssClass="table table-bordered" AutoGenerateColumns="false">
                    <RowStyle Font-Size="Medium"/>
                    <HeaderStyle BackColor="#274F74" ForeColor="#e4ecf3" />
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
                        <asp:BoundField DataField="FechaString" HeaderText="Fecha Toma" />
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
    </div>
            <a href="Default.aspx">Default.aspx</a>

    <%--       <table id="example" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Age</th>
                <th>Start date</th>
                <th>Salary</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Tiger Nixon</td>
                <td>System Architect</td>
                <td>Edinburgh</td>
                <td>61</td>
                <td>2011/04/25</td>
                <td>$320,800</td>
            </tr>
            <tr>
                <td>Garrett Winters</td>
                <td>Accountant</td>
                <a href="App_Data/">App_Data/</a>
                <td>Tokyo</td>
                <td>63</td>
                <td>2011/07/25</td>
                <td>$170,750</td>
            </tr>
            <tr>
                <td>Ashton Cox</td>
                <td>Junior Technical Author</td>
                <td>San Francisco</td>
                <td>66</td>
                <td>2009/01/12</td>
                <td>$86,000</td>
            </tr>
            <tr>
                <td>Cedric Kelly</td>
                <td>Senior Javascript Developer</td>
                <td>Edinburgh</td>
                <td>22</td>
                <td>2012/03/29</td>
                <td>$433,060</td>
            </tr>
            <tr>
                <td>Airi Satou</td>
                <td>Accountant</td>
                <td>Tokyo</td>
                <td>33</td>
                <td>2008/11/28</td>
                <td>$162,700</td>
            </tr>
            <tr>
                <td>Brielle Williamson</td>
                <td>Integration Specialist</td>
                <td>New York</td>
                <td>61</td>
                <td>2012/12/02</td>
                <td>$372,000</td>
            </tr>
            <tr>
                <td>Herrod Chandler</td>
                <td>Sales Assistant</td>
                <td>San Francisco</td>
                <td>59</td>
                <td>2012/08/06</td>
                <td>$137,500</td>
            </tr>
            <tr>
                <td>Rhona Davidson</td>
                <td>Integration Specialist</td>
                <td>Tokyo</td>
                <td>55</td>
                <td>2010/10/14</td>
                <td>$327,900</td>
            </tr>
            <tr>
                <td>Colleen Hurst</td>
                <td>Javascript Developer</td>
                <td>San Francisco</td>
                <td>39</td>
                <td>2009/09/15</td>
                <td>$205,500</td>
            </tr>
            <tr>
                <td>Sonya Frost</td>
                <td>Software Engineer</td>
                <td>Edinburgh</td>
                <td>23</td>
                <td>2008/12/13</td>
                <td>$103,600</td>
            </tr>
          
            <tr>
                <td>Caesar Vance</td>
                <td>Pre-Sales Support</td>
                <td>New York</td>
                <td>21</td>
                <td>2011/12/12</td>
                <td>$106,450</td>
            </tr>
            <tr>
                <td>Doris Wilder</td>
                <td>Sales Assistant</td>
                <td>Sydney</td>
                <td>23</td>
                <td>2010/09/20</td>
                <td>$85,600</td>
            </tr>      
        </tbody>
        <tfoot>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Age</th>
                <th>Start date</th>
                <th>Salary</th>
            </tr>
        </tfoot>
    </table>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable();
        });

        function generatePDF() {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
        }

        function GenerarPrint(sURL) {
            var oHiddFrame = document.createElement("iframe");
            oHiddFrame.onload = setPrint;
            oHiddFrame.style.visibility = "hidden";
            oHiddFrame.style.position = "fixed";
            oHiddFrame.style.right = "0";
            oHiddFrame.style.bottom = "0";
            oHiddFrame.src = sURL;
            document.body.appendChild(oHiddFrame);
        }

        function setPrint() {

            this.contentWindow._container_ = this;
            this.contentWindow.onbeforeunload = closePrint;
            this.contentWindow.onafterprint = closePrint;
            this.contentWindow.focus(); // Required for IE
            this.contentWindow.print();
        }

        function closePrint(){
            document.body.removeChild(this._container_);
        }

    </script>
</asp:Content>


