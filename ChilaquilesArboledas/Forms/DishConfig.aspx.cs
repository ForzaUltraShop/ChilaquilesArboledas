using FoodApp.BusinessLayer;
using FoodApp.DataModels;
using FoodApp.DataModels.Shared;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace ChilaquilesArboledas.Forms
{
    public partial class DishConfig : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Request.QueryString["DishId"] != null)
                {
                    long.TryParse(Request.QueryString["DishId"], out long dishIdentifier);
                    hdfDishIdentifier.Value = dishIdentifier.ToString();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "loadHeader", string.Format("loadControlsByDishId({0});", dishIdentifier), true);
                }
            }
        }


        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseDTO<CategoriesDTO> LoadControlsByDishId(long dishIdentifier)
        {
            var response = new CategoriesLogic().CategoryByDishIdentifierGetItem(dishIdentifier);
            return response;
        }
    }
}