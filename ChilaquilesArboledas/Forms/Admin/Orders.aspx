<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Admin.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        /* Styles for wrapping the search box */
        .main {
            width: 100%;
            margin: 5px auto;
        }

        /* Bootstrap 4 text input with search icon */
        .has-search .form-control {
            padding-left: 2.375rem;
        }

        .has-search .form-control-feedback {
            position: absolute;
            z-index: 2;
            display: block;
            width: 2.375rem;
            height: 2.375rem;
            line-height: 2.375rem;
            text-align: center;
            pointer-events: none;
            color: #aaa;
        }
    </style>
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/modal.css?{0}", DateTime.Now.Ticks)) %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4>Ordenes</h4>
    <hr />
    <div class="main">
        <div class="d-flex">
            <div class="p-2">
                <div class="form-group has-search">
                    <i class="fa fa-search form-control-feedback"></i>
                    <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Buscar..." ClientIDMode="Static"></asp:TextBox>
                    <asp:LinkButton runat="server" Id="lnkSearchOrder">
                    </asp:LinkButton>
                </div>
            </div>
            <div class="ml-auto p-2">
                <asp:Button runat="server" ID="btnAddNewCategory" CssClass="btn btn-success" Text="+ Agregar nueva categor&iacute;a" OnClick="" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-12 ">
                <div class="table-responsive">
                    <asp:GridView ID="grwOrders" runat="server"
                        Width="100%"
                        CssClass="table table-striped table-bordered table-hover"
                        AutoGenerateColumns="False"
                        DataKeyNames=""
                        EmptyDataText="No hay informacion por mostrar"
                        OnRowCommand="">
                    </asp:GridView>
                    <asp:HiddenField runat="server" ID="hdfDeleteCategoryIdentifier" Value="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
