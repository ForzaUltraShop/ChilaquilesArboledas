namespace ChilaquilesArboledas.Forms
{
    using FoodApp.BusinessLayer;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Web.UI;

    public partial class CartCheckOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var order = new OrdersLogic().OrderGetItem(1);
                //if (Session["OrderId"] != null)
                //{
                    //long.TryParse(Session["OrderId"].ToString(), out long orderIdentifier);
                    //if (orderIdentifier > default(long))
                    //{
                        hdfOrderIdentifier.Value = "1"; //orderIdentifier.ToString();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "loadCartItems", "loadCart();", true);
                    //}
                //}
                //else
                //{

                //}
            }
        }

        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseDTO<OrderDTO> OrderGetItem(long orderIdentifier)
        {
            return new OrdersLogic().OrderGetItem(orderIdentifier);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseDTO<OrderDTO> CartCheckOutExecute(CartCheckOutDTO cartCheckOut)
        {
            return new OrdersLogic().CartCheckOutExecute(new RequestDTO<CartCheckOutDTO>
            {
                Item = cartCheckOut
            });
        }
    }
}