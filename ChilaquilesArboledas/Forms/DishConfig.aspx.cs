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
            return new CategoriesLogic().CategoryByDishIdentifierGetItem(dishIdentifier);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseDTO<OrderDTO> CreateOrder(long dishIdentifier, int[] complementsList, int quantity)
        {
            var orderResponse = new ResponseDTO<OrderDTO>();
            if(HttpContext.Current.Session["CustomerId"] != null && dishIdentifier > default(long) && complementsList.Length > default(int) && quantity > default(int))
            {
                int.TryParse(HttpContext.Current.Session["CustomerId"].ToString(), out int customerIdentifier);

                long orderIdentifier = 0;
                if (HttpContext.Current.Session["OrderId"] != null)
                {
                    long.TryParse(HttpContext.Current.Session["OrderId"].ToString(), out orderIdentifier);
                }

                var orderRequest = new RequestDTO<OrderDTO>
                {
                    Item = new OrderDTO
                    {
                        OrderIdentifier = orderIdentifier,
                        Customer = new CustomersDTO
                        {
                            CustomerIdentifier = customerIdentifier
                        },
                        OrderDetailList = new List<OrderDetailDTO>(),
                        ItemsCount = quantity,
                    },
                    OperationType = orderIdentifier > default(long) ? OperationType.Update : OperationType.Create
                };

                foreach(var complementIdentifier in complementsList)
                {
                    orderRequest.Item.OrderDetailList.Add(new OrderDetailDTO
                    {
                        Dish = new DishesDTO
                        {
                            DishIdentifier = dishIdentifier
                        },
                        DishComplementIdentifier = complementIdentifier
                    });
                }

                var orderLogic = new OrdersLogic();
                orderResponse = orderLogic.OrderExecute(orderRequest);

                //Agrego la orden que se genero a session
                if (orderResponse.Success)
                {
                    HttpContext.Current.Session["OrderId"] = orderResponse.Result.OrderIdentifier;
                }
            }
            
            return orderResponse;
        }
    }
}