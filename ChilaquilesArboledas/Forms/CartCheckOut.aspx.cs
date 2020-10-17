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
                if (Session["OrderId"] != null)
                {
                    long.TryParse(Session["OrderId"].ToString(), out long orderIdentifier);
                    if (orderIdentifier > default(long))
                    {
                        hdfOrderIdentifier.Value = orderIdentifier.ToString();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "loadCartItems", "loadCart();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "loadCartItems", "carHide();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "loadCartItems", "carHide();", true);
                }
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
            var cartCheckOutResponse = new OrdersLogic().CartCheckOutExecute(new RequestDTO<CartCheckOutDTO>
            {
                Item = cartCheckOut
            });

            if (cartCheckOutResponse.Success)
            {
                HttpContext.Current.Session["OrderId"] = null;
            }

            return cartCheckOutResponse;
        }

        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseDTO<CustomersDTO> GetCustomerAddress()
        {
            var response = new ResponseDTO<CustomersDTO>
            {
                Success = true,
                Result = new CustomersDTO
                {
                    CustomerAddress = HttpContext.Current.Session["CustomerAddress"].ToString() ?? string.Empty
                }
            };
            return response;
        }

        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseDTO<bool> OrderDetailDelete(long orderIdentifier, string dishUniqueKey)
        {
            var response = new OrdersLogic().OrderDetailDelete(orderIdentifier,dishUniqueKey);
            return response;
        }
    }
}