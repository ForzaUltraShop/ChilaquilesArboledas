<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class='row'>
        <div class='col-4' style='text-align: center;'>
            <img src='../assets/images/platoChilaquiles.jpg' alt='' width='90px' height='90px' />
        </div>
        <div class='col-8'>
            <h3 class='align-left'>Chilaquiles</h3>
            <span id='spnPrice'>$40.00</span> </div>
    </div>
    <br />
    <div class='row' style='background-color: silver'><strong>Selecciona tu salsa:</strong></div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='radio' class='rbtOption' value='0' name='rbtSeccion3' />&nbsp;Salsa verde			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>Sin costo adicional			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='radio' class='rbtOption' value='0' name='rbtSeccion3' />&nbsp;Salsa roja			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>Sin costo adicional			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: silver'><strong>Agrega ingredientes</strong></div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' value='5' />&nbsp;Con pollito			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$5.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' value='5' />&nbsp;Con carne			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$5.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' value='10' />&nbsp;Con Chorizo			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$10.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' value='0' />&nbsp;Crema			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>Sin costo adicional			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' value='0' />&nbsp;Queso			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>Sin costo adicional			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' value='0' />&nbsp;Cebolla			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>Sin costo adicional			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: silver'><strong>Agrega un extra</strong></div>
    <div class='row' style='background-color: white; padding-top: 5px; padding-bottom: 5px;'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' value='20' />&nbsp;Café de olla			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$20.00			</td>
            </tr>
        </table>
    </div>

</asp:Content>
