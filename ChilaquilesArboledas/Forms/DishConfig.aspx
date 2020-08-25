<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DishConfig.aspx.cs" Inherits="ChilaquilesArboledas.Forms.DishConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContent" class="container" style="background-color: white">
        
    </div>
    <br />
    <br />
    <asp:HiddenField runat="server" ID="hdfDishIdentifier" ClientIDMode="Static" />
    <%--<script type="text/javascript" src='<%=ResolveUrl(string.Format("~/assets/js/dishConfig.js?{0}", DateTime.Now.Ticks)) %>'></script>--%>
    <script type="text/javascript" src='<%=ResolveUrl("~/assets/js/dishConfig.js") %>'></script>
</asp:Content>
