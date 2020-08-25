namespace ChilaquilesArboledas.Forms.Admin
{
    using FoodApp.BusinessLayer;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class DishesEdit : Page
    {
        private enum DeleteSender
        {
            Sections = 0,
            Complements = 1
        };

        private readonly DishesLogic dishesLogic = new DishesLogic();

        private string ActionType
        {
            get
            {
                return ViewState["DishEditAction"].ToString();
            }
            set
            {
                ViewState["DishEditAction"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["DishIdentifier"] != null)
                {
                    loadDishControls();
                    loadSectionGrid();
                    loadDishComplementsGrid();
                    ActionType = "update";
                }
                else
                {
                    txtDishName.Text = string.Empty;
                    txtDishDescription.Text = string.Empty;
                    ActionType = "create";
                }
            }
        }

        private void loadDishComplementsGrid()
        {
            long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
            int.TryParse(ddlDishSection.SelectedValue, out int dishSectionIdentifier);
            if(dishIdentifier > default(long) && ddlDishSection.Items.Count > default(int))
            {
                var dishComplementsResponse = dishesLogic.DishComplementsGetFilteredList(dishIdentifier, dishSectionIdentifier);
                if (dishComplementsResponse.Success)
                {
                    grwComplements.DataSource = dishComplementsResponse.Result;
                    grwComplements.DataBind();
                }
                else
                {
                    //TODO:Alert
                    grwComplements.DataSource = null;
                    grwComplements.DataBind();
                }
            }
        }

        private void loadDishControls()
        {
            long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
            var dishResponse = dishesLogic.DishesGetItem(new RequestDTO<DishesDTO>
            {
                Item = new DishesDTO
                {
                    DishIdentifier = dishIdentifier
                }
            });

            if (dishResponse.Success)
            {
                var dishItem = dishResponse.Result;
                txtDishName.Text = dishItem.DishName;
                txtDishDescription.Text = dishItem.DishDescription;
                txtDishPrice.Text = dishItem.DishPrice.ToString("C");
                chkDishStatus.Checked = dishItem.IsActive;
            }
            else
            {
                //TODO: Alert
            }
        }

        private void loadSectionGrid()
        {
            long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
            var dishSectionList = dishesLogic.DishSectionsByDishGetList(dishIdentifier);
            if (dishSectionList.Result != null && dishSectionList.Result.Any())
            {
                grwSections.DataSource = dishSectionList.Result;
                grwSections.DataBind();

                //Tambien se carga el dropdownlist de secciones
                ddlDishSection.DataSource = dishSectionList.Result;
                ddlDishSection.DataTextField = "DishSectionName";
                ddlDishSection.DataValueField = "DishSectionId";
                ddlDishSection.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void grwSections_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            switch (e.CommandName)
            {
                case "Insert":
                    long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
                    var txtInsertSectionName = ((GridView)sender).FooterRow.FindControl("txtInsertSectionName") as TextBox;
                    var chkAllowMultipleOptions = ((GridView)sender).FooterRow.FindControl("chkInsertAllowMultiple") as CheckBox;

                    if (txtInsertSectionName != null && !string.IsNullOrEmpty(txtInsertSectionName.Text) && dishIdentifier > default(long))
                    {
                        bool isCreated = dishesLogic.DishSectionExecute(new RequestDTO<DishesDTO>
                        {
                            Item = new DishesDTO
                            {
                                DishIdentifier = dishIdentifier,
                                DishSectionsList = new List<DishSectionsDTO>
                                {
                                    new DishSectionsDTO
                                    {
                                        DishSectionName = txtInsertSectionName.Text.Trim(),
                                        AllowMultipleOptions = chkAllowMultipleOptions.Checked
                                    }
                                }
                            },
                            OperationType = OperationType.Create
                        }).Success;

                        if (!isCreated)
                        {
                            //TODO: Error alert
                        }

                        grwSections.ShowFooter = default(bool);
                        loadSectionGrid();
                    }
                    break;
                case "SectionDelete":
                    var row = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)];
                    var sectionIdentifier = grwSections.DataKeys[row.RowIndex].Value.ToString();
                    showDeleteModal(sectionIdentifier, DeleteSender.Sections);
                    break;
            }
        }

        protected void grwSections_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grwSections.EditIndex = e.NewEditIndex;
            loadSectionGrid();
        }

        protected void grwSections_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int.TryParse(grwSections.DataKeys[e.RowIndex]["DishSectionId"].ToString(), out int sectionIdentifier);
            if(grwSections.Rows[e.RowIndex].FindControl("txtSectionName") is TextBox txtSectionName && sectionIdentifier > default(int))
            {
                var chkAllowMultipleOptions = grwSections.Rows[e.RowIndex].FindControl("chkEditAllowMultiple") as CheckBox;
                bool isUpdated = dishesLogic.DishSectionExecute(new RequestDTO<DishesDTO>
                {
                    Item = new DishesDTO
                    {
                        DishSectionsList = new List<DishSectionsDTO>
                        {
                            new DishSectionsDTO
                            {
                                DishSectionId = sectionIdentifier,
                                DishSectionName = txtSectionName.Text.Trim(),
                                AllowMultipleOptions = chkAllowMultipleOptions.Checked
                            }
                        }
                    },
                    OperationType = OperationType.Update
                }).Success;

                if (!isUpdated)
                {
                    //TODO: Error alert
                }
                grwSections.EditIndex = -1;
                loadSectionGrid();
            }
        }

        protected void grwSections_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grwSections.EditIndex = -1;
            loadSectionGrid();
        }

        protected void btnAddNewSection_Click(object sender, EventArgs e)
        {
            grwSections.ShowFooter = true;
            loadSectionGrid();
        }

        protected void btnAddNewComplement_Click(object sender, EventArgs e)
        {
            grwComplements.ShowFooter = true;
            loadDishComplementsGrid();
        }

        protected void grwComplements_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Insert":
                    long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
                    int.TryParse(ddlDishSection.SelectedValue, out int dishSectionIdentifier);

                    var txtComplementName = ((GridView)sender).FooterRow.FindControl("txtInsertComplementNameName") as TextBox;
                    var chkIncludedInOrder = ((GridView)sender).FooterRow.FindControl("chkInsertIncludedInOrder") as CheckBox;
                    var txtComplementPrice = ((GridView)sender).FooterRow.FindControl("txtInsertAditionalCost") as TextBox;
                    decimal complementPrice = string.IsNullOrEmpty(txtComplementPrice.Text.Trim()) ? decimal.Zero : Convert.ToDecimal(txtComplementPrice.Text.Trim());

                    var insertResponse = dishesLogic.DishComplementsExecute(new RequestDTO<DishesDTO>
                    {
                        Item = new DishesDTO
                        {
                            DishIdentifier = dishIdentifier,
                            DishSectionsList = new List<DishSectionsDTO>
                            {
                                new DishSectionsDTO
                                {
                                    DishSectionId = dishSectionIdentifier,
                                    DishComplementsList = new List<DishComplementsDTO>
                                    {
                                        new DishComplementsDTO
                                        {
                                            DishComplementName = txtComplementName.Text.Trim(),
                                            IsIncludedInOrder = chkIncludedInOrder.Checked,
                                            AditionalCost = complementPrice
                                        }
                                    }
                                }
                            }
                        },
                        OperationType = OperationType.Create
                    });

                    if (!insertResponse.Success)
                    {
                        //TODO: Alert
                    }

                    grwComplements.ShowFooter = default(bool);
                    loadDishComplementsGrid();
                    
                    break;
                case "ComplementDelete":
                    var row = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)];
                    var complementIdentifier = grwComplements.DataKeys[row.RowIndex].Value.ToString();
                    showDeleteModal(complementIdentifier, DeleteSender.Complements);
                    break;
            }
        }

        protected void grwComplements_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grwComplements.EditIndex = e.NewEditIndex;
            loadDishComplementsGrid();
        }

        protected void grwComplements_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int.TryParse(grwComplements.DataKeys[e.RowIndex]["DishComplementId"].ToString(), out int dishComplementIdentifier);
            long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
            int.TryParse(ddlDishSection.SelectedValue, out int dishSectionIdentifier);

            if (dishComplementIdentifier > default(int) && dishIdentifier > default(long) && dishSectionIdentifier > default(int)) 
            {
                var txtComplementName = grwComplements.Rows[e.RowIndex].FindControl("txtEditComplementName") as TextBox;
                var chkIsIncludeInOrder = grwComplements.Rows[e.RowIndex].FindControl("chkEditIncludedInOrder") as CheckBox;
                var txtComplementPrice = grwComplements.Rows[e.RowIndex].FindControl("txtEditAditionalCost") as TextBox;
                decimal complementPrice = string.IsNullOrEmpty(txtComplementName.Text.Trim()) ? decimal.Zero : Convert.ToDecimal(txtComplementPrice.Text.Trim());

                var updateResponse = dishesLogic.DishComplementsExecute(new RequestDTO<DishesDTO>
                {
                    Item = new DishesDTO
                    {
                        DishIdentifier = dishIdentifier,
                        DishSectionsList = new List<DishSectionsDTO>
                        {
                            new DishSectionsDTO
                            {
                                DishSectionId = dishSectionIdentifier,
                                DishComplementsList = new List<DishComplementsDTO>
                                {
                                    new DishComplementsDTO
                                    {
                                        DishComplementId = dishComplementIdentifier,
                                        DishComplementName = txtComplementName.Text.Trim(),
                                        IsIncludedInOrder = chkIsIncludeInOrder.Checked,
                                        AditionalCost = complementPrice
                                    }
                                }
                            }
                        }
                    },
                    OperationType = OperationType.Update
                });

                if (!updateResponse.Success)
                {
                    //TODO: Alert
                }

                grwComplements.EditIndex = -1;
                loadDishComplementsGrid();
            }
        }

        protected void grwComplements_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grwComplements.EditIndex = -1;
            loadSectionGrid();
        }

        protected void ddlDishSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDishComplementsGrid();
        }

        private void showDeleteModal(string deleteIdentifier, DeleteSender sender)
        {
            hdfDeleteIdentifier.Value = deleteIdentifier;
            hdfDeleteSender.Value = ((int)sender).ToString();

            switch (sender)
            {
                case DeleteSender.Sections:
                    lblDeleteModalTitle.Text = "Eliminar Sección";
                    lblDeleteMessageConfirmation.Text = "¿Estás seguro de eliminar esta sección (también sus items se eliminaran)?";
                    break;
                case DeleteSender.Complements:
                    lblDeleteModalTitle.Text = "Eliminar Item";
                    lblDeleteMessageConfirmation.Text = "¿Estás seguro de eliminar este item?";
                    break;
            }
            mpeConfirmDelete.Show();
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            DeleteSender deleteSender = (DeleteSender)Convert.ToInt32(hdfDeleteSender.Value);
            switch (deleteSender)
            {
                case DeleteSender.Sections:
                    deleteSection();
                    break;
                case DeleteSender.Complements:
                    deleteComplement();
                    break;
            }
        }

        private void deleteComplement()
        {
            long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
            int.TryParse(ddlDishSection.SelectedValue, out int dishSectionIdentifier);

            var dishItem = new DishesDTO
            {
                DishIdentifier = dishIdentifier,
                DishSectionsList = new List<DishSectionsDTO>
                {
                    new DishSectionsDTO
                    {
                        DishSectionId = Convert.ToInt32(dishSectionIdentifier),
                        DishComplementsList = new List<DishComplementsDTO>
                        {
                            new DishComplementsDTO
                            {
                                DishComplementId = long.Parse(hdfDeleteIdentifier.Value)
                            }
                        }
                    }
                }
            };

            var filter = new RequestDTO<DishesDTO>
            {
                Item = dishItem,
                OperationType = OperationType.Delete
            };

            ResponseDTO<DishComplementsDTO> dishComplementsResponse = dishesLogic.DishComplementsExecute(filter);
            if (dishComplementsResponse.Success)
            {
                loadDishComplementsGrid();
            }
            else
            {
                //TODO: Alert
            }
        }

        private void deleteSection()
        {
            long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
            var dishItem = new DishesDTO
            {
                DishIdentifier = dishIdentifier,
                DishSectionsList = new List<DishSectionsDTO>
                {
                    new DishSectionsDTO
                    {
                        DishSectionId = Convert.ToInt32(hdfDeleteIdentifier.Value)
                    }
                }
            };

            var filter = new RequestDTO<DishesDTO>
            {
                Item = dishItem,
                OperationType = OperationType.Delete
            };

            ResponseDTO<DishSectionsDTO> deleteSectionResponse = dishesLogic.DishSectionExecute(filter);
            if (deleteSectionResponse.Success)
            {
                loadSectionGrid();
            }
            else
            {
                //TODO: Alert
            }
        }
    }
}