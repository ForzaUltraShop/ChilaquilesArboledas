<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartCheckOut.aspx.cs" Inherits="ChilaquilesArboledas.Forms.CartCheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="car_content">
        <div class="row" style="height: 5px; background-color: white">
            &nbsp;
        </div>
        <div class="row" style="background-color: silver; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <strong>Método de entrega</strong>
        </div>
        <div class="row" style="background-color: white; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="0" checked="checked" />&nbsp;Para llevar
        </div>
        <div class="row" style="background-color: white; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="1" />&nbsp;Para ir comiendo
        </div>
        <div class="row" style="background-color: white; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <div class="col text-left" style="padding-left: 0px">
                <input type="radio" class="rbtDeliveryOption" name="deliveryOption" value="2" />&nbsp;Entrega a domicilio
            </div>
            <div class="col text-right">
                <a href="#" id="lnkShareMyLocation">Compartir mi ubicación.</a>
                <i id="OkShareLocation" class="fa fa-check"></i>
            </div>
        </div>

        <div class="row" style="background-color: white; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <div class="col text-left" style="padding-left: 0px">
                <input type="text" class="form-control" id="txtCustomerAddress" />
            </div>
        </div>

        <div class="row" style="background-color: silver; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <strong>Resumen de tu orden</strong>
        </div>
        <div class="row" style="background-color: white; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <table id="tblOrderDetail" border="0" style="width: 100%">
                <tbody>
                </tbody>
                <tfoot>
                </tfoot>
            </table>
        </div>
        <div class="row" style="height: 25px; background-color: white">
            &nbsp;
        </div>
        <div class='row' style='background-color: silver; padding-top: 5px; padding-bottom: 5px;'>
            <strong>Instrucciones adicionales</strong>
        </div>
        <div class="row" style="height: 25px; background-color: white">
            &nbsp;
        </div>
        <div class='row' style="padding-top: 5px; padding-bottom: 5px; background-color: white">
            <div class='col-12 text-center'>
                <textarea id="txtAditionalComments" rows='3' style='width: 100%; resize: none; text-transform: lowercase;' class='form-control' placeholder="Comentarios adicionales a tu orden (máx. 50 caracteres)" maxlength="50"></textarea>
                <br />
            </div>
        </div>
        <div class="row" style="background-color: white">
            <div class="col-lg-12">
                <input id="btnSendOrder" type="button" class="btn btn-success btn-lg btn-block" value="Realizar Pedido" />
                <br />
                <br />
            </div>
        </div>
        <div class="row" style="height: 5px; background-color: white">
            &nbsp;
        </div>

        <asp:HiddenField runat="server" ID="hdfOrderIdentifier" Value="0" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdfLatitude" Value="" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdfLongitude" Value="" ClientIDMode="Static" />
    </div>
    <div id="car_empty">
        <div class="row d-flex justify-content-center" style="background-color: white; padding-top: 5px; padding-bottom: 5px; padding-left: 5px">
            <img src="../assets/images/car_empty.png" style="width:70%!important;min-height:500px!important;object-fit:scale-down!important" />
        </div>        
    </div>
    <%--<script type="text/javascript" src='<%=ResolveUrl(string.Format("~/assets/js/cart.js?{0}", DateTime.Now.Ticks)) %>'></script>--%>
    <script type="text/javascript" src='<%=ResolveUrl("~/assets/js/helpers/lodash.min.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveUrl("~/assets/js/cart.js") %>'></script>
</asp:Content>
