namespace ChilaquilesArboledas.Forms
{
    using FoodApp.BusinessLayer;
    using System;
    using System.Web.UI;
    using System.Web.Services;
    using System.Web.Script.Services;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;

    public partial class Especiales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Request.QueryString["CategoryId"] != null)
                {
                    int.TryParse(Request.QueryString["CategoryId"], out int categoryIdentifier);
                    
                    //El codigo 999 es para agendar un pedido
                    if(categoryIdentifier == 999)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "loadDishes", string.Format("loadDishesByCategoryId({0});", categoryIdentifier), true);
                    }
                }
                else
                {
                    
                }
            }
        }


        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseListDTO<DishesDTO> DishesGetByCategoryIdentifier(int categoryIdentifier)
        {
            var dishesLogic = new DishesLogic();
            var dishesResponse = new ResponseListDTO<DishesDTO>();
            try
            {
                dishesResponse = dishesLogic.DishesByCategoryGetList(categoryIdentifier);
            }
            catch (Exception exception)
            {
                //TODO: Add exception message
            }
            return dishesResponse;
        }
    }
}