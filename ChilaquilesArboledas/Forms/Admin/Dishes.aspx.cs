namespace ChilaquilesArboledas.Forms.Admin
{
    using FoodApp.BusinnessLayer.Interface;
    using System;
    using System.Web.UI;
    using FoodApp.DataModels.Shared;
    using FoodApp.DataModels;
    using FoodApp.Models;

    public partial class Dishes : Page
    {
        public IDishesLogic dishesLogic { get; set; }

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
                //TODO:Alerta
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
                //TODO: Alerta
            }
        }

        protected void grwDishes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string dishIdentifier = grwDishes.DataKeys[rowIndex]["DishIdentifier"].ToString();
                switch (e.CommandName)
                {
                    case "DishEdit":
                        showDetailPage(dishIdentifier);
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

        private void showDetailPage(string dishIdentifier)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Forms/Admin/DishesEdit?DishIdentifier={0}", dishIdentifier)));
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
                    //TODO:Alert message
                }
            }
        }
    }
}