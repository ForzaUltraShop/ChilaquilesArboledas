<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class='row'>
        <div class='col-4'>
            <img src='../assets/images/platoChilaquiles.jpg' alt='' width='90px' height='90px' />
        </div>
        <div class='col-8'>
            <h3 class='align-middle'>Chilaquiles</h3>
        </div>
    </div>
    <div class='row' style='background-color: silver'><strong>Selecciona tu salsa:</strong></div>
    <br />
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='radio' class='rbtOption' name='rbtSeccion3' />&nbsp;undefined			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$0.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='radio' class='rbtOption' name='rbtSeccion3' />&nbsp;undefined			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$0.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: silver'><strong>Agrega ingredientes</strong></div>
    <br />
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' />&nbsp;Con pollito			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>Sin costo adicional			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' />&nbsp;Con carne			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$5.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' />&nbsp;Con Chorizo			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>Sin costo adicional			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' />&nbsp;Crema			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$0.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' />&nbsp;Queso			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$0.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' />&nbsp;Cebolla			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$0.00			</td>
            </tr>
        </table>
    </div>
    <div class='row' style='background-color: silver'><strong>Agrega un extra</strong></div>
    <br />
    <div class='row' style='background-color: white'>
        <table width='100%'>
            <tr>
                <td width='50%'>
                    <input type='checkbox' class='chkOption' />&nbsp;Café de olla			
                    <br />
                </td>
                <td width='50%' style='text-align: right; padding-right: 5px'>$20.00			</td>
            </tr>
        </table>
    </div>

</asp:Content>
