<%@ Page Title="  " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reporteWebFichaTecnica.aspx.cs" Inherits="SystemLab.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="myDivToPrint">

        <div class="panel panel-default" style="margin-bottom: 7px;">
            <div class="panel-body" style="padding: 0; height: 82px;">
                <div class="row">
                    <div class="col-xs-3">
                        <img src="Images/logoindecal.png" style="width: 100%; height: 80px; margin: 0;" />
                    </div>
                    <div class="col-xs-9 text-center">
                        <h5 class=""><strong>INDECAL SRL - Laboratorio Suelos y Hormigón</strong></h5>
                        <div style="border: 3px solid; border-color: #163e81; margin: 0;"></div>
                        <p style="margin: 0;">Santo Domingo / Bávaro, email: info@indecalsrl.com  Teléfono Oficina 809-375-6085</p>
                        <p style="margin: 0;"><strong>www.indecalsrl.com</strong></p>
                    </div>
                </div>
            </div>
        </div>

        <div class="text-center">
            <h6 style="margin: 0;"><strong>FICHA TECNICA HORMIGON APLICADO EN OBRA</strong></h6>
            <p style="margin-bottom: 7px;">ASTM C31 - Making and Curing Concrete Test Especímenes in the Field</p>
        </div>

        <div class="panel panel-default">
            <div class="panel-body" style="padding: 5px;">
                <div class="row">
                    <div class="col-xs-3">
                        <p class="txtHeader"><strong>CLIENTE:</strong> Ingenieria Estrella</p>
                        <p class="txtHeader"><strong>FECHA REPORTE:</strong> 19/09/2019</p>
                    </div>
                    <div class="col-xs-3">
                        <p class="txtHeader"><strong>OBRA:</strong> Resid. Antares del Este</p>
                        <p class="txtHeader"><strong>DIR. OBRA:</strong> Ciudad Juan Bosch, Sto. Dgo Este</p>
                    </div>
                    <div class="col-xs-2">
                        <p class="txtHeader"><strong>HORMIGONERA:</strong> Concredom</p>
                        <p class="txtHeader"><strong>FECHA VACIADO:</strong> 15/09/2019</p>
                    </div>
                    <div class="col-xs-2">
                        <p class="txtHeader"><strong>TOMA PROBETAS:</strong> INDECAL SRL</p>
                        <p class="txtHeader"><strong>VOLUMEN:</strong> 65M3</p>
                    </div>
                    <div class="col-xs-2 text-center">
                        <p class="txtHeader">No. Regstro Lab.</p>
                        <p class="text-danger txtHeader"><strong>1446</strong></p>
                    </div>
                </div>
            </div>
        </div>

        <div>
            <h6 style="color: red; margin-bottom: 0;">RESULTADOS ENSAYOS AL HORMIGON FRESCO - NORMAS  ASTM (C172 / C 1064 / C143 / C 31)        
            </h6>
        </div>

        <table class="table table-bordered text-center">

            <tr>
                <td>CONDUCE CAMION</td>
                <td>HORA LLEGADA</td>
                <td>HORA FINAL VACIADO</td>
                <td>RESIST. F'c (Kg/cm2)</td>
                <td>SLUMP (Pulg)</td>
                <td>TEMP (oC)</td>
                <td>No. Reg.</td>
                <td>Cant.</td>
                <td>Diametro x Largo(cm)</td>
                <td>ELEMENTO ESTRUCTURAL</td>
                <td>SECTOR</td>
                <td>Edad: 7 dias</td>
                <td>Edad: 14 dias</td>
                <td>Edad: 28 dias</td>
            </tr>
            <tr>
                <td>s001</td>
                <td>2:40</td>
                <td>2:40</td>
                <td>210.00</td>
                <td>8.50</td>
                <td>32.00</td>
                <td>1446</td>
                <td>6</td>
                <td>10x20</td>
                <td>losa 1</td>
                <td>Muro y losa apart 1</td>
                <td>180 | 85 %</td>
                <td>00.00 | 00.00%</td>
                <td>00.00 | 00.00%</td>
            </tr>
            <tr>
                <td>s002</td>
                <td>2:40</td>
                <td>2:40</td>
                <td>210.00</td>
                <td>8.50</td>
                <td>32.00</td>
                <td>1446</td>
                <td>6</td>
                <td>10x20</td>
                <td>losa 1</td>
                <td>Muro y losa apart 1</td>
                <td>180 | 85 %</td>
                <td>00.00 | 00.00%</td>
                <td>00.00 | 00.00%</td>
            </tr>
            <tr>
                <td>s003</td>
                <td>2:40</td>
                <td>2:40</td>
                <td>210.00</td>
                <td>8.50</td>
                <td>32.00</td>
                <td>1446</td>
                <td>6</td>
                <td>10x20</td>
                <td>losa 1</td>
                <td>Muro y losa apart 1</td>
                <td>180 | 85 %</td>
                <td>00.00 | 00.00%</td>
                <td>00.00 | 00.00%</td>
            </tr>
        </table>

        <div class="row">
            <div class="col-xs-10">
                <p style="margin:0;">Nota:</p>
                <p>Este reporte presenta los ensayos al hormigón fresco, correspondientes a los camiones que fueron muestreados para la realización de probetas (cilindros) para resistencias a compresión. Cada camión en obra fue verificado y ensayado antes de ser aplicado; para ver los demás resultados solicitar scanner de reporte original de campo.</p>
            </div>
            <div class="col-xs-2">
                <img src="Images/firma.png" style="width: 85%; height: 110px;" />
            </div>
            <div class="col-xs-12">
                <div style="border: 1px solid; margin: 25px"></div>
            </div>
            <div class="col-xs-12 text-center">
                <div class="col-xs-6">
                    <p>Preparador por: Ing. Hector Jimenez</p>
                </div>
                <div class="col-xs-6">
                    <p>Aprobador por: Ing. Carlos Peña</p>
                </div>
            </div>
        </div>

    </div>
    <style>
        .divHeader {
            /*border: 1px solid;
            border-color: gray;*/
        }

        .divImagen {
        }

        .divImagen {
        }

        .body-content {
            margin: 0px !important;
            background-color: white;
        }

        .txtHeader {
            font-size: 10px;
        }

        td {
            font-size: 9px;
        }

        p {
            font-size: 9px;
        }

        @media print {
            .myDivToPrint {                
                background-color: white;
                height: 100%;
                width: 100%;
                position: fixed;
                top: 0;
                left: 0;
                margin: 0;
                padding: 15px;
                font-size: 14px;
                line-height: 18px;
            }

            footer{
                visibility:hidden;
            }

            title{
                visibility:hidden;
            }
        }
    </style>


</asp:Content>

