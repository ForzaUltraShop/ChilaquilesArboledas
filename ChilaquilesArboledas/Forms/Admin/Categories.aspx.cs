namespace ChilaquilesArboledas.Forms.Admin
{
    using FoodApp.BusinessLayer;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Categories : Page
    {
        private readonly CategoriesLogic categoriesLogic = new CategoriesLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                categoriesBind();
            }
        }

        private void categoriesBind()
        {
            var request = new RequestDTO<CategoriesDTO>
            {
                Item = new CategoriesDTO(),
                WordFilter = txtSearch.Text.Trim()
            };

            var categoriesResponse = categoriesLogic.CategoriesGetFilteredList(request);
            if (categoriesResponse.Success)
            {
                grwCategories.DataSource = categoriesResponse.Result;
                grwCategories.DataBind();
            }
        }

        protected void grwCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                var categoryIdentifier = grwCategories.DataKeys[rowIndex]["CategoryIdentifier"].ToString();
                switch (e.CommandName)
                {
                    case "CategoryEdit":
                        showDetailPage(categoryIdentifier);
                        break;
                    case "CategoryDelete":
                        showDeleteModal(categoryIdentifier);
                        break;
                    case "ViewDishes":
                        showRelatedDishes(categoryIdentifier);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void showRelatedDishes(string categoryIdentifier)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Forms/Admin/Dishes?CategoryIdentifier={0}", categoryIdentifier)));
        }

        private void showDetailPage(string categoryIdentifier)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Forms/Admin/CategoryEdit?CategoryIdentifier={0}", categoryIdentifier)));
        }

        private void showDeleteModal(string categoryIdentifier)
        {
            if (!string.IsNullOrEmpty(categoryIdentifier))
            {
                hdfDeleteCategoryIdentifier.Value = categoryIdentifier;
                mpeConfirmDelete.Show();
            }
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdfDeleteCategoryIdentifier.Value))
            {
                bool isRecordDeleted = categoriesLogic.CategoriesExecute(new RequestDTO<CategoriesDTO>
                {
                    Item = new CategoriesDTO
                    {
                        CategoryIdentifier = Convert.ToInt32(hdfDeleteCategoryIdentifier.Value)
                    },
                    OperationType = OperationType.Delete
                }).Success;

                if (isRecordDeleted)
                {
                    showUserMessage("El registro se elimino correctamente", "success");
                    hdfDeleteCategoryIdentifier.Value = string.Empty;
                    categoriesBind();
                }
                else
                {
                    showUserMessage("No fue posible eliminar el registro", "error");
                }
            }
        }

        protected void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/Forms/Admin/CategoryEdit"));
        }

        private void showUserMessage(string message, string alertType)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("swal('{0}','{1}','{2}')", "Admin", message, alertType);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("swal"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "swal", script, true);
            }
        }
    }
}