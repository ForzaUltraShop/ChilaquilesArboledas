<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Dishes.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Admin.Dishes" %>
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
                    <div>Eliminar Platillo</div>
                </div>
            </div>
            <br />
            <br />
            <div>
                <asp:Label runat="server" ID="lblDeleteMessageConfirmation" Text="¿Estas seguro de eliminar este platillo?"></asp:Label>
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
    <h4>Platillos</h4>
    <hr />
    <div class="main">
        <div class="d-flex">
            <div class="p-2">
                <%--<div class="form-group">
                    <label for="exampleFormControlSelect1">Categor&iacute;as</label>
                    <asp:DropDownList id="ddlCategoryFilter" runat="server" class="form-control"></asp:DropDownList>
                </div>--%>
            </div>
            <div class="ml-auto p-2">
                <asp:Button runat="server" ID="btnAddNewDish" CssClass="btn btn-success" Text="+ Agregar nuevo platillo" OnClick="btnAddNewDish_Click" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-12 ">
                <div class="table-responsive">
                    <asp:GridView ID="grwDishes" runat="server"
                        Width="100%"
                        CssClass="table table-striped table-bordered table-hover"
                        AutoGenerateColumns="False"
                        DataKeyNames="DishIdentifier"
                        EmptyDataText="No hay informacion por mostrar"
                        OnRowCommand="grwDishes_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="DishIdentifier" HeaderText="#" />
                            <asp:BoundField DataField="DishName" HeaderText="Categoría" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                            <asp:BoundField DataField="DishDescription" HeaderText="Descripción" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                            <asp:BoundField DataField="DishPrice" HeaderText="Precio" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" DataFormatString="{0:C}" />
                            <asp:TemplateField HeaderText="Imagen">
                                <ItemTemplate>
                                    <asp:Image ID="DishImage" runat="server" ImageUrl='<%#"~/assets/images/" + Eval("DishImagePath").ToString() %>' width="150px" height="90px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="160px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Editar" CommandName="DishEdit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                        <i class='fa fa-edit'></i> 
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkDelete" Tooltip="Eliminar" CommandName="DishDelete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                        <i class='fa fa-trash'></i> 
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField runat="server" ID="hdfDeleteDishIdentifier" Value="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
