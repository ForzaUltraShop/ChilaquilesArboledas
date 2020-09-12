<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartCheckOut.aspx.cs" Inherits="ChilaquilesArboledas.Forms.CartCheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="height:5px; background-color:white">
        &nbsp;
    </div>
    <div class="row" style="background-color:silver; padding-top: 5px; padding-bottom: 5px; padding-left:5px">
        <strong>Método de entrega</strong>
    </div>
    <div class="row" style="background-color: white; padding-top: 5px;padding-bottom: 5px; padding-left:5px">
        <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="0" />&nbsp;Para llevar
    </div>
    <div class="row" style="background-color: white; padding-top: 5px;padding-bottom: 5px; padding-left:5px">
        <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="1" />&nbsp;Para ir comiendo
    </div>
    <div class="row" style="background-color: white; padding-top: 5px;padding-bottom: 5px; padding-left:5px">
        <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="2" />&nbsp;Entrega a domicilio
    </div>
    <div class="row" style="background-color:silver; padding-top: 5px; padding-bottom: 5px; padding-left:5px">
        <strong>Resumen de tu orden</strong>
    </div>
    <div class="row" style="background-color: white; padding-top: 5px; padding-bottom: 5px; padding-left:5px">
        <table id="tblOrderDetail" border="0" style="width:100%">
            <tbody>

            </tbody>
            <tfoot>

            </tfoot>
            <%--<tr>
                <td style="width:80%">
                    <span style="font-weight:bold">x1</span>&nbsp;<strong>Chilaquiles Tradicionales</strong>
                </td>
                <td style="width:20%; text-align:right">
                   <span style="color:#28a745;">$40.00</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color:grey">Crema</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color:grey">Queso</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color:grey">Cebolla</span>
                </td>
            </tr>--%>
        </table>
    </div>
    <div class="row" style="height:25px; background-color:white">
        &nbsp;
    </div>
    <div class='row' style='background-color: silver; padding-top: 5px; padding-bottom: 5px;'>
        <strong>Instrucciones adicionales</strong>
    </div>
    <div class="row" style="height:25px; background-color:white">
        &nbsp;
    </div>
    <div class='row' style="padding-top: 5px; padding-bottom: 5px; background-color:white">
        <div class='col-12 text-center'>
            <textarea rows='3' style='width: 100%; resize: none; text-transform: capitalize;' class='form-control'></textarea>
            <br />
        </div>
    </div>
    <div class="row" style="background-color:white">
        <div class="col-lg-12">
            <input id="btnAddToCart" type="button" class="btn btn-success btn-lg btn-block" value="Realizar Pedido" />
            <br />
            <br />
        </div>
    </div>
    <div class="row" style="height:5px; background-color:white">
        &nbsp;
    </div>

    <asp:HiddenField runat="server" ID="hdfOrderIdentifier" Value="0" ClientIDMode="Static" />
    <%--<script type="text/javascript" src='<%=ResolveUrl(string.Format("~/assets/js/cart.js?{0}", DateTime.Now.Ticks)) %>'></script>--%>
    <script type="text/javascript" src='<%=ResolveUrl("~/assets/js/helpers/lodash.min.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveUrl("~/assets/js/cart.js") %>'></script>
</asp:Content>