<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Admin.CategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/modal.css?{0}", DateTime.Now.Ticks)) %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4>Edici&oacute;n de Categorias</h4>
    <hr />
    <div class="w-75">
        <div class="form-group row pl-3">
            <strong>
                <asp:Label runat="server" ID="lblCategoryName" Text="Nombre:" AssociatedControlID="txtCategoryName"></asp:Label>
            </strong>
            <asp:TextBox runat="server" ID="txtCategoryName" placeholder="(Máx. 100 caracteres)" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group row pl-3">
            <strong>
                <asp:Label runat="server" ID="lblDescription" Text="Descripción:" AssociatedControlID="txtDescription"></asp:Label>
            </strong>
            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" placeholder="(Máx. 250 caracteres)" class="form-control"></asp:TextBox>
        </div>
        <div runat="server" id="divImageFileUpload" class="input-group mb-3">
            <div class="input-group-prepend">
                <span class="input-group-text">Imagen</span>
            </div>
            <div runat="server"  class="custom-file">
                <asp:FileUpload runat="server" ID="fuCategoryImage" class="custom-file-input" Width="100%" ClientIDMode="Static" />
                <asp:Label runat="server" ID="lblFileUpload" CssClass="custom-file-label" AssociatedControlID="fuCategoryImage" ClientIDMode="Static" Text="Seleccionar..."></asp:Label>
            </div>
        </div>
        <div runat="server" id="divCategoryImage">
            <asp:Image runat="server" ID="imgCategory" Visible="true" Width="150px" Height="90px" ImageUrl="~/assets/images/" />
            <br />
            <br />
        </div>
        <div>
            <asp:CheckBox runat="server" ID="chkIsActive" Text=" Activo/Inactivo" />
        </div>
        <br />
        <br />
        <div class="modal-button-aligment">
            <asp:Button runat="server" ID="btnCancel" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            <asp:Button runat="server" ID="btnSave" Text="Guardar" CssClass="btn btn-success" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
