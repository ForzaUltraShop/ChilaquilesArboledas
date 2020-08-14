
namespace ChilaquilesArboledas.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using FoodApp.DataModels.Shared;
    using FoodApp.DataModels;
    using System.Web.Services;
    using FoodApp.BusinessLayer;
    using Newtonsoft.Json;
    using System.Web.Script.Services;

    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod()]
        public static ResponseListDTO<CategoriesDTO> CategoriesGetList()
        {
            var categoryLogic = new CategoriesLogic();
            var categoriesResponse = new ResponseListDTO<CategoriesDTO>();
            try
            {
                var filter = new RequestDTO<CategoriesDTO>
                {
                    Item = new CategoriesDTO(),
                    WordFilter = string.Empty
                };
                categoriesResponse = categoryLogic.CategoriesGetFilteredList(filter);
            }
            catch (Exception exception)
            {
                throw;
            }
            return categoriesResponse;
        }
    }
}