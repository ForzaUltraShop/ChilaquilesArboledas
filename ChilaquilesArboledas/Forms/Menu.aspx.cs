
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

    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static ResponseListDTO<CategoriesDTO> CategoriesGetList()
        {
            return null;
        }
    }
}