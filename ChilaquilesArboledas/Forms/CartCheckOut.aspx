<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartCheckOut.aspx.cs" Inherits="ChilaquilesArboledas.Forms.CartCheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="height:5px; background-color:white">
            &nbsp;
        </div>
        <div class="row" style="background-color:silver; padding-top: 5px; padding-bottom: 5px; padding-left:5px">
            <strong>Método de entrega</strong>
        </div>
        <div class="row" style="background-color: white; padding-top: 5px;padding-bottom: 5px;">
            <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="0" />&nbsp;Para llevar
        </div>
        <div class="row" style="background-color: white; padding-top: 5px;padding-bottom: 5px;">
            <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="1" />&nbsp;Para ir comiendo
        </div>
        <div class="row" style="background-color: white; padding-top: 5px;padding-bottom: 5px;">
            <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="2" />&nbsp;Entrega a domicilio
        </div>
        <div class="row" style="background-color:silver; padding-top: 5px; padding-bottom: 5px; padding-left:5px">
            <strong>Resumen de tu orden</strong>
        </div>
        <div class="row" style="background-color: white; padding-top: 5px; padding-bottom: 5px;">
            <table border="1" style="width:100%">
                <tr>
                    <td style="width:50%">
                        x<span style="font-weight:bold">1</span>&nbsp;<strong>Chilaquiles Tradicionales</strong>
                    </td>
                    <td style="width:50%; text-align:right">
                        $40.00
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Crema
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Queso
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Cebolla
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
    </div>
</asp:Content>