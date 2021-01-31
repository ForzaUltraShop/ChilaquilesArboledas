namespace ChilaquilesArboledas.Forms
{
    using FoodApp.BusinessLayer;
    using System;
    using System.Web.UI;
    using System.Web.Services;
    using System.Web.Script.Services;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using System.Web;

    public partial class Especiales : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CategoryId"] != null)
                {
                    int.TryParse(Request.QueryString["CategoryId"], out int categoryIdentifier);

                    //El codigo 999 es para agendar un pedido
                    if (categoryIdentifier == 999)
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