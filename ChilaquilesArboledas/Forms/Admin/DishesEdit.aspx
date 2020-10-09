<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DishesEdit.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Admin.DishesEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/modal.css?{0}", DateTime.Now.Ticks)) %>" />
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/adminAccordion.css?{0}", DateTime.Now.Ticks)) %>" />
    <style>
        .active {
            background-color: white !important;
        }

        .ajax__tab_xp .ajax__tab_header {
            font-size: 13px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="smManager"></asp:ScriptManager>
    <br />
    <h4>Edici&oacute;n de Platillos</h4>
    <hr />
    <div class="form-row">
        <div class="col-md-12 col-lg-12">
            <ajaxToolkit:TabContainer runat="server"
                Width="100%"
                ActiveTabIndex="0"
                OnDemand="true"
                AutoPostBack="true"
                TabStripPlacement="Top"
                CssClass="ajax__tab_xp"
                ScrollBars="None"
                UseVerticalStripPlacement="false" 
                OnActiveTabChanged="Unnamed_ActiveTabChanged" >
                <ajaxToolkit:TabPanel runat="server"
                    HeaderText="Informacion general"
                    Enabled="true"
                    ScrollBars="Auto"
                    OnDemandMode="Once">
                    <ContentTemplate>
                        <br />
                        <div class="form-group row">
                            <div class="col-md-3">
                                <strong>
                                    <asp:Label runat="server" ID="lblDishName" Text="Nombre:" AssociatedControlID="txtDishName"></asp:Label>
                                </strong>
                                <asp:TextBox runat="server" ID="txtDishName" placeholder="(Máx. 100 caracteres)" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <strong>
                                    <asp:Label runat="server" ID="lblDishDescription" Text="Descripción:" AssociatedControlID="txtDishDescription"></asp:Label>
                                </strong>
                                <asp:TextBox runat="server" ID="txtDishDescription" placeholder="(Máx. 100 caracteres)" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <strong>
                                    <asp:Label runat="server" ID="lblDishPrice" Text="Precio:" AssociatedControlID="txtDishPrice"></asp:Label>
                                </strong>
                                <asp:TextBox runat="server" ID="txtDishPrice" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-6">
                                <strong>
                                    <asp:Label runat="server" ID="lblFileUpload" Text="Imagen asociada:" AssociatedControlID="fuDishImage"></asp:Label>
                                </strong>
                                <div runat="server" id="divDishImage">
                                    <asp:Image runat="server" ID="imgDish" Visible="false" Width="150px" Height="90px" ImageUrl="~/assets/images/" />
                                </div>
                                <br />
                                <asp:FileUpload runat="server" ID="fuDishImage" Width="100%" ClientIDMode="Static" />
                            </div>
                            <div class="col-md-6">
                                <div class="form-check-inline">
                                    <label class="form-check-label">
                                        <asp:CheckBox runat="server" ID="chkDishStatus" Text="" />&nbsp;Activo/Inactivo
                                    </label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div>
                            <asp:Button runat="server" ID="btnCancel" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                            <asp:Button runat="server" ID="btnSave" Text="Guardar" CssClass="btn btn-success" OnClick="btnSave_Click" />
                        </div>
                        <br />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server"
                    HeaderText="Secciones"
                    Enabled="true"
                    ScrollBars="Auto"
                    OnDemandMode="Once">
                    <ContentTemplate>
                        <br />
                        <div>
                            <asp:GridView runat="server"
                                ID="grwSections"
                                Width="70%"
                                CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False"
                                DataKeyNames="DishSectionId"
                                OnRowCommand="grwSections_RowCommand"
                                OnRowEditing="grwSections_RowEditing"
                                OnRowUpdating="grwSections_RowUpdating"
                                OnRowCancelingEdit="grwSections_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderText="Nombre de la Sección">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSectionName" runat="server" Text='<%#Eval("DishSectionName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSectionName" runat="server" CssClass="form-control" MaxLength="50" Text='<%#Eval("DishSectionName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtInsertSectionName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="¿Permite opción múltiple?">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkAllowMultiple" Checked='<%# Convert.ToBoolean(Eval("AllowMultipleOptions")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkEditAllowMultiple" Checked='<%# Convert.ToBoolean(Eval("AllowMultipleOptions")) %>' />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:CheckBox runat="server" ID="chkInsertAllowMultiple" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Editar" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                                <i class='fa fa-edit'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDelete" ToolTip="Eliminar" CommandName="SectionDelete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                                <i class='fa fa-trash'></i> 
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Editar" CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                                <i class='fa fa-floppy-o'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDelete" ToolTip="Eliminar" CommandName="Cancel" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                                <i class='fa fa-times'></i> 
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Editar" CommandName="Insert" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                                <i class='fa fa-floppy-o'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDelete" ToolTip="Eliminar" CommandName="Cancel" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
                                                <i class='fa fa-times'></i> 
                                            </asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table style="background-color: white;">
                                        <tr>
                                            <td><strong>Nombre de la sección:</strong></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtEmptySectionName"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><strong>¿Permite opción múltiple?</strong></td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkEmptyAllowMultipleOption" /></td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnAddNewSection" Text="+ Agregar Sección" CssClass="btn btn-success" OnClick="btnAddNewSection_Click" />
                        </div>
                        <br />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server"
                    HeaderText="Items por seccion"
                    Enabled="true"
                    ScrollBars="Auto"
                    OnDemandMode="Once">
                    <ContentTemplate>
                        <br />
                        <div class="form-group row">
                            <div class="col-md-3">
                                <strong>
                                    <asp:Label runat="server" ID="lblDishSectionDropdownList" Text="Elije una seccíon:" AssociatedControlID="ddlDishSection"></asp:Label></strong>
                                <asp:DropDownList runat="server" ID="ddlDishSection" CssClass="form-control" OnSelectedIndexChanged="ddlDishSection_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div>
                            <asp:GridView ID="grwComplements"
                                runat="server"
                                CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False"
                                DataKeyNames="DishComplementId"
                                OnRowCommand="grwComplements_RowCommand"
                                OnRowEditing="grwComplements_RowEditing"
                                OnRowUpdating="grwComplements_RowUpdating"
                                OnRowCancelingEdit="grwComplements_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblComplementName" runat="server" Text='<%#Eval("DishComplementName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditComplementName" runat="server" CssClass="form-control" MaxLength="50" Text='<%#Eval("DishComplementName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtInsertComplementNameName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="¿Está incluido en la orden?">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkIncludedInOrder" runat="server" Checked='<%# Convert.ToBoolean(Eval("IsIncludedInOrder")) %>' Enabled="false"></asp:CheckBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkEditIncludedInOrder" runat="server" Checked='<%# Convert.ToBoolean(Eval("IsIncludedInOrder")) %>'></asp:CheckBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:CheckBox ID="chkInsertIncludedInOrder" runat="server" Checked="true"></asp:CheckBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cargo extra">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAditionalCost" runat="server" Text='<%# String.Format("{0:C}", Eval("AditionalCost")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditAditionalCost" runat="server" CssClass="form-control" MaxLength="50" Text='<%#Eval("AditionalCost") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtInsertAditionalCost" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Editar" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-edit'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDelete" ToolTip="Eliminar" CommandName="ComplementDelete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-trash'></i> 
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Editar" CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-floppy-o'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDelete" ToolTip="Eliminar" CommandName="Cancel" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-times'></i> 
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Editar" CommandName="Insert" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-floppy-o'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDelete" ToolTip="Eliminar" CommandName="Cancel" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-times'></i> 
                                            </asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table style="background-color: white;">
                                        <tr>
                                            <td><strong>Nombre:</strong></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtEmptyComplementName"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><strong>¿Está incluido en la orden?:</strong></td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkEmptyComplementIncludedInOrder" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><strong>Cargo extra:</strong></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtEmptyComplementAditionalCost"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnAddNewComplement" Text="+ Agregar nuevo item" CssClass="btn btn-success" OnClick="btnAddNewComplement_Click" />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>

    <%--Modal de confirmacion de baja--%>
    <asp:HiddenField runat="server" ID="hdfDeleteIdentifier" Value="0" />
    <asp:HiddenField runat="server" ID="hdfDeleteSender" Value="0" />
    <asp:Panel runat="server" ID="pnlConfirmDelete" CssClass="ventanaModal">
        <div class="popup_Container">
            <div id="PopupHeader" class="popup_TitleBar">
                <div class="border-bottom">
                    <div>
                        <asp:Label runat="server" ID="lblDeleteModalTitle"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div>
                <asp:Label runat="server" ID="lblDeleteMessageConfirmation" Text=""></asp:Label>
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
        ID="mpeConfirmDelete"
        BackgroundCssClass="fondoModal"
        TargetControlID="btnModalPopup"
        PopupControlID="pnlConfirmDelete">
    </ajax:ModalPopupExtender>
    <div style="display: none">
        <asp:Button runat="server" ID="btnModalPopup" ClientIDMode="Static" />
    </div>
</asp:Content>
