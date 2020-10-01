<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Admin.CategoryEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/modal.css?{0}", DateTime.Now.Ticks)) %>" />
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/adminAccordion.css?{0}", DateTime.Now.Ticks)) %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="smManager"></asp:ScriptManager>
    <br />
    <h4>Edici&oacute;n de Categorias</h4>
    <hr />
    <div>
        <ajax:Accordion runat="server" ID="ajaxAccordion" HeaderCssClass="headerCssClass"
            ContentCssClass="contentCssClass"
            HeaderSelectedCssClass="headerSelectedCss"
            FadeTransitions="true"
            TransitionDuration="500"
            AutoSize="None" SelectedIndex="0">
            <Panes>
                <ajaxToolkit:AccordionPane runat="server" ID="DishesPanel1" Width="100%">
                    <Header>Información General</Header>
                    <Content>
                        <br />
                        <div class="form-group row">
                            <div class="col-md-4">
                                <strong>
                                    <asp:Label runat="server" ID="lblCategoryName" Text="Nombre:" AssociatedControlID="txtCategoryName"></asp:Label>
                                </strong>
                                <asp:TextBox runat="server" ID="txtCategoryName" placeholder="(Máx. 100 caracteres)" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <strong>
                                    <asp:Label runat="server" ID="lblDescription" Text="Descripción:" AssociatedControlID="txtDescription"></asp:Label>
                                </strong>
                                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" placeholder="(Máx. 250 caracteres)" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <strong>
                                    <asp:Label runat="server" ID="lblFileUpload" Text="Imagen asociada:" AssociatedControlID="fuCategoryImage"></asp:Label>
                                </strong>
                                <div runat="server" id="divCategoryImage">
                                    <asp:Image runat="server" ID="imgCategory" Visible="false" Width="150px" Height="90px" ImageUrl="~/assets/images/" />
                                </div>
                                <br />
                                <asp:FileUpload runat="server" ID="fuCategoryImage" Width="100%" ClientIDMode="Static" />                
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-12">
                                <asp:CheckBox runat="server" ID="chkIsActive" Text=" Activo/Inactivo" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-12">
                                <div class="modal-button-aligment">
                                    <asp:Button runat="server" ID="btnCancel" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                    <asp:Button runat="server" ID="btnSave" Text="Guardar" CssClass="btn btn-success" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </Content>
                </ajaxToolkit:AccordionPane>
            </Panes>
        </ajax:Accordion>
    </div>
</asp:Content>