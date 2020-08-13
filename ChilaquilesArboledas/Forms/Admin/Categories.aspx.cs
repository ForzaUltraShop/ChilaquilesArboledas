namespace ChilaquilesArboledas.Forms.Admin
{
    using FoodApp.BusinnessLayer.Interface;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Categories : Page
    {
        public ICategoriesLogic categoriesLogic { get; set; }

        /// <summary>
        /// Carga los datos iniciales de la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    //TODO:Add alert
                    hdfDeleteCategoryIdentifier.Value = string.Empty;
                    categoriesBind();
                }
                else
                {

                }
            }
        }

        protected void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/Forms/Admin/CategoryEdit"));
        }
    }
}