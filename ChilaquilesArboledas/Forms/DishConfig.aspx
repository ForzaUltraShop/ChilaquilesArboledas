<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DishConfig.aspx.cs" Inherits="ChilaquilesArboledas.Forms.DishConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .col-centered{
            margin: 0 auto;
            float: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContent" class="container" style="background-color: white">
    </div>
    <div class="container" style="background-color: white">
        <div class='row' style='background-color: silver; padding-top:5px; padding-bottom:5px;'>
            <strong>Instrucciones adicionales</strong>
        </div>
        <div class='row' style="padding-top:5px; padding-bottom:5px;">
            <div class='col-12 text-center'>
                <textarea rows='3' style='width: 100%; resize: none; text-transform: capitalize;' class='form-control'></textarea>
                <br />
            </div>
        </div>
        <div class="row" style="background-color: white;">
            <div class="col-lg-12 col-centered">
                <div class="input-group">
                    <span class="input-group-btn">
                        <button type="button" id="btnMinus" class="btn btn-secondary">
                            <i class="fa fa-minus"></i>
                        </button>
                    </span>
                    <span id="spnQuantity" style="font-size: large; border: 1px solid silver; padding-left: 10px; padding-right: 10px; padding-top:5px">
                        1
                    </span>
                    <span class="input-group-btn">
                        <button type="button" id="btnPlus" class="btn btn-secondary">
                            <i class="fa fa-plus"></i>
                        </button>
                    </span>
                    <br />
                    
                </div>
            </div>
            <br />
            <br />
        </div>
        <div class="row">
            <div class="col-lg-12">
                <input id="btnAddToCart" type="button" class="btn btn-warning btn-lg btn-block" value="Agregar al carrito" />
                <br />
                <br />
            </div>
        </div>
    </div>
    <br />
    <br />
    <asp:HiddenField runat="server" ID="hdfDishIdentifier" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdfNewDishPrice" ClientIDMode="Static" />
    <%--<script type="text/javascript" src='<%=ResolveUrl(string.Format("~/assets/js/dishConfig.js?{0}", DateTime.Now.Ticks)) %>'></script>--%>
    <script type="text/javascript" src='<%=ResolveUrl("~/assets/js/dishConfig.js") %>'></script>
</asp:Content>
