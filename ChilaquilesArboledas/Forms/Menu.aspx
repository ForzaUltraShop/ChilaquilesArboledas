<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .title {
            margin-bottom: 50px;
            text-transform: uppercase;
        }

        .card-block {
            font-size: 1em;
            position: relative;
            margin: 0;
            padding: 1em;
            border: none;
            box-shadow: none;
        }

        .btn {
            margin-top: auto;
        }

        @media only screen and (min-width: 360px) {
          .d-block {
            width: 100% !important;
          }
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContent">

    </div>
    <br />
    <br />
    <script type="text/javascript" src='<%=ResolveUrl(string.Format("~/assets/js/menu.js?{0}", DateTime.Now.Ticks)) %>'></script>
</asp:Content>