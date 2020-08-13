<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Admin.Categories" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

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
    <asp:ScriptManager runat="server" ID="smManager"></asp:ScriptManager>
    <asp:Panel runat="server" ID="pnlConfirmDelete" CssClass="ventanaModal">
        <div class="popup_Container">
            <div id="PopupHeader" class="popup_TitleBar">
                <div class="border-bottom">
                    <div>Eliminar Categor&iacute;a</div>
                </div>
            </div>
            <br />
            <br />
            <div>
                <asp:Label runat="server" ID="lblDeleteMessageConfirmation" Text="¿Estas seguro de eliminar esta categoria?"></asp:Label>
            </div>
            <br />
            <br />
            <div class="modal-button-aligment">
                <asp:Button runat="server" ID="btnCancelDelete" Text="Cancelar" CssClass="btn btn-danger" />
                <asp:Button runat="server" ID="btnConfirmDelete" Text="Si, eliminar" CssClass="btn btn-success" OnClick="btnConfirmDelete_Click" />
            </div>
        </div>
    </asp:Panel>
    <ajax:ModalPopupExtender runat="server"
        Id="mpeConfirmDelete"
        BackgroundCssClass="fondoModal"
        TargetControlID="btnModalPopup"
        PopupControlID="pnlConfirmDelete">
    </ajax:ModalPopupExtender>
    <div style="display:none">
        <asp:Button runat="server" ID="btnModalPopup" ClientIDMode="Static" />
    </div>
    

    <br />
    <h4>Categorias</h4>
    <hr />
    <div class="main">
        <div class="d-flex">
            <div class="p-2">
                <div class="form-group has-search">
                    <span class="fa fa-search form-control-feedback"></span>
                    <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Buscar..." ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="ml-auto p-2">
                <asp:Button runat="server" ID="btnAddNewCategory" CssClass="btn btn-success" Text="+ Agregar nueva categor&iacute;a" OnClick="btnAddNewCategory_Click" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-12 ">
                <div class="table-responsive">
                    <asp:GridView ID="grwCategories" runat="server"
                        Width="100%"
                        CssClass="table table-striped table-bordered table-hover"
                        AutoGenerateColumns="False"
                        DataKeyNames="CategoryIdentifier"
                        EmptyDataText="No hay informacion por mostrar"
                        OnRowCommand="grwCategories_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="CategoryIdentifier" HeaderText="#" />
                            <asp:BoundField DataField="CategoryName" HeaderText="Categoría" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                            <asp:BoundField DataField="CategoryDescription" HeaderText="Descripción" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                            <asp:TemplateField HeaderText="Imagen">
                                <ItemTemplate>
                                    <asp:Image ID="CategoryImage" runat="server" ImageUrl='<%#"~/assets/images/" + Eval("CategoryImagePath").ToString() %>' width="150px" height="90px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="160px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEdit" CommandName="CategoryEdit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' ToolTip="Editar" CssClass="btn btn-outline-secondary">
                                        <i class='fa fa-edit'></i> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkDelete" CommandName="CategoryDelete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' ToolTip="Eliminar" CssClass="btn btn-outline-secondary">
                                        <i class='fa fa-trash'></i> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkViewRelatedDishes" CommandName="ViewDishes" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' ToolTip="Ver platillos" CssClass="btn btn-outline-secondary">
                                        <i class='fa fa-list-ul'></i> 
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField runat="server" ID="hdfDeleteCategoryIdentifier" Value="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>