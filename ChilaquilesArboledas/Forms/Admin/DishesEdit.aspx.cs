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
            switch(e.CommandName)
            {
                case "Insert":
                    var txtInsertSectionName = ((GridView)sender).FooterRow.FindControl("txtInsertSectionName") as TextBox;
                    long.TryParse(Request.QueryString["DishIdentifier"], out long dishIdentifier);
                    if(txtInsertSectionName != null && !string.IsNullOrEmpty(txtInsertSectionName.Text) && dishIdentifier > default(long))
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
                                        DishSectionName = txtInsertSectionName.Text.Trim()
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
                bool isUpdated = dishesLogic.DishSectionExecute(new RequestDTO<DishesDTO>
                {
                    Item = new DishesDTO
                    {
                        DishSectionsList = new List<DishSectionsDTO>
                        {
                            new DishSectionsDTO
                            {
                                DishSectionId = sectionIdentifier,
                                DishSectionName = txtSectionName.Text.Trim()
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

        }

        protected void grwComplements_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grwComplements_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grwComplements_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grwComplements_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void ddlDishSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDishComplementsGrid();
        }

    }
}