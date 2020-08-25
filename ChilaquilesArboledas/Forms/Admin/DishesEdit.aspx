<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DishesEdit.aspx.cs" Inherits="ChilaquilesArboledas.Forms.Admin.DishesEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/modal.css?{0}", DateTime.Now.Ticks)) %>" />
    <link rel="stylesheet" href="<%:ResolveUrl(string.Format("~/assets/styles/adminAccordion.css?{0}", DateTime.Now.Ticks)) %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="smManager"></asp:ScriptManager>
    <br />
    <h4>Edici&oacute;n de Platillos</h4>
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
                            <div class="col-md-3">
                                <div class="form-check-inline">
                                    <label class="form-check-label">
                                        <asp:CheckBox runat="server" ID="chkDishStatus" Text="" />&nbsp;Activo/Inactivo
                                    </label>
                                </div>
                            </div>
                        </div>
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane runat="server" ID="DishesPanel2">
                    <Header>Configuraci&oacute;n de secciones</Header>
                    <Content>
                        <br />
                        <div style="padding-left:30%">
                            <asp:GridView ID="grwSections" runat="server"
                                Width="70%"
                                CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False"
                                DataKeyNames="DishSectionId"
                                EmptyDataText="No hay informacion por mostrar"
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
                            </asp:GridView>
                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnAddNewSection" Text="+ Agregar Sección" CssClass="btn btn-success" OnClick="btnAddNewSection_Click" />
                        </div>
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane runat="server" ID="DishesPanel3">
                    <Header>Items por sección</Header>
                    <Content>
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
                                            <asp:Label ID="lblAditionalCost" runat="server"  Text='<%# String.Format("{0:C}", Eval("AditionalCost")) %>' ></asp:Label>
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
                                            <asp:LinkButton runat="server" ID="lnkEditComplement" ToolTip="Editar" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-edit'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDeleteComplement" ToolTip="Eliminar" CommandName="ComplementDelete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-trash'></i> 
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit_EditComplement" ToolTip="Editar" CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-floppy-o'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkEdit_DeleteComplement" ToolTip="Eliminar" CommandName="Cancel" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-times'></i> 
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton runat="server" ID="lnkInsertComplement" ToolTip="Editar" CommandName="Insert" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-floppy-o'></i> 
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkCancelInsertComplement" ToolTip="Eliminar" CommandName="Cancel" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-outline-secondary">
				                                <i class='fa fa-times'></i> 
                                            </asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align:center; width:350px">
                                        No hay items dados de alta para esta secci&oacute;n
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnAddNewComplement" Text="+ Agregar nuevo item" CssClass="btn btn-success" OnClick="btnAddNewComplement_Click" />
                        </div>
                    </Content>
                </ajaxToolkit:AccordionPane>
            </Panes>
        </ajax:Accordion>
        <br />
        <br />
        <div class="modal-button-centered-aligment">
            <asp:Button runat="server" ID="btnCancel" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            <asp:Button runat="server" ID="btnSave" Text="Guardar" CssClass="btn btn-success" OnClick="btnSave_Click" />
        </div>
        <br />
        <br />
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
        Id="mpeConfirmDelete"
        BackgroundCssClass="fondoModal"
        TargetControlID="btnModalPopup"
        PopupControlID="pnlConfirmDelete">
    </ajax:ModalPopupExtender>
    <div style="display:none">
        <asp:Button runat="server" ID="btnModalPopup" ClientIDMode="Static" />
    </div>

</asp:Content>