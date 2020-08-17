<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especiales.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Especiales" %>
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

        .card {
            font-size: 1em;
            overflow: hidden;
            padding: 5px;
            border: none;
            border-radius: .28571429rem;
            box-shadow: 0 1px 3px 0 #d4d4d5, 0 0 0 1px #d4d4d5;
            margin-top: 20px;
            cursor:pointer;
        }

        .btn {
            margin-top: auto;
        }

        @media only screen and (min-width: 360px) {
          .d-block {
            width: 100% !important;
          }

          body{
              background-color:gold;
          }
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="divContent">

    </div>
    <br />
    <br />
    <script type="text/javascript" src='<%=ResolveUrl(string.Format("~/assets/js/especiales.js?{0}", DateTime.Now.Ticks)) %>'></script>
</asp:Content>
