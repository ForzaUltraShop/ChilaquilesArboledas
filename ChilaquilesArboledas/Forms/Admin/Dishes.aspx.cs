namespace ChilaquilesArboledas.Forms.Admin
{
    using System;
    using System.Web.UI;
    using FoodApp.DataModels.Shared;
    using FoodApp.DataModels;
    using FoodApp.Models;
    using FoodApp.BusinessLayer;
    using System.Web;

    public partial class Dishes : Page
    {
        private readonly DishesLogic dishesLogic = new DishesLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CategoryIdentifier"] != null)
                {
                    loadDishesByCategory();
                }
            }
            else
            {
                showUserMessage("El identificador de la categoria es requerido", "error");
            }
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

        private void loadDishesByCategory()
        {
            int.TryParse(Request.QueryString["CategoryIdentifier"], out int categoryIdentifier);
            if (categoryIdentifier > default(int))
            {
                var dishesResult = dishesLogic.DishesByCategoryGetList(categoryIdentifier);
                if (dishesResult.Success)
                {
                    grwDishes.DataSource = dishesResult.Result;
                    grwDishes.DataBind();
                }
            }
            else
            {
                showUserMessage("No se encontraron registros", "warning");
            }
        }

        protected void grwDishes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string dishIdentifier = grwDishes.DataKeys[rowIndex]["DishIdentifier"].ToString();
                int.TryParse(Request.QueryString["CategoryIdentifier"], out int categoryIdentifier);

                switch (e.CommandName)
                {
                    case "DishEdit":
                        showDetailPage(dishIdentifier, categoryIdentifier.ToString());
                        break;
                    case "DishDelete":
                        showDeleteModal(dishIdentifier);
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

        private void showDeleteModal(string dishIdentifier)
        {
            hdfDeleteDishIdentifier.Value = dishIdentifier;
            mpeConfirmDelete.Show();
        }

        private void showDetailPage(string dishIdentifier, string categoryIdentifier)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Forms/Admin/DishesEdit?DishIdentifier={0}&CategoryIdentifier={1}", dishIdentifier, categoryIdentifier)));
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            long.TryParse(hdfDeleteDishIdentifier.Value, out long dishIdentifier);
            if(dishIdentifier > default(long))
            {
                bool isDeleted = dishesLogic.DishesExecute(new RequestDTO<DishesDTO>
                {
                    Item = new DishesDTO
                    {
                        DishIdentifier = dishIdentifier
                    },
                    OperationType = OperationType.Delete
                }).Success;

                if (isDeleted)
                {
                    loadDishesByCategory();
                }
                else
                {
                    showUserMessage("No fue posible eliminar el registro", "error");
                }
            }
        }

        protected void btnAddNewDish_Click(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["CategoryIdentifier"], out int categoryIdentifier);
            Response.Redirect(ResolveUrl(string.Format("~/Forms/Admin/DishesEdit?CategoryIdentifier={0}", categoryIdentifier)));
        }
    }
}