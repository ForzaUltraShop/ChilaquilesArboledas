namespace ChilaquilesArboledas.Forms
{
    using FoodApp.BusinessLayer;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Hosting;
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


        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseDTO<PostalCodesDTO> GetMinimumFeeByOrder(long orderIdentifier)
        {
            var response = new ResponseDTO<PostalCodesDTO> { Result = new PostalCodesDTO() };
            try
            {
                var orderResponse = new OrdersLogic().OrderGetItem(orderIdentifier);
                if (orderResponse.Success)
                {
                    decimal orderTotalAmount = orderResponse.Result.ItemsTotalAmount;
                    if(orderTotalAmount > default(int))
                    {
                        decimal minimumFeeForVipUser = getMinimumFeeForVipUser(orderResponse);
                        if (minimumFeeForVipUser > default(decimal))
                        {
                            response.Result.MinimumTotalAmount = minimumFeeForVipUser;
                            response.Success = true;
                        }
                        else
                        {
                            var postalCodesList = new List<PostalCodesDTO>();
                            string customerPostalCode = orderResponse.Result.Customer.CustomerPostalCode;
                            using (StreamReader file = File.OpenText(HostingEnvironment.MapPath("~/assets/files/PostalCodes.json")))
                            {
                                using (var jsonTextReader = new JsonTextReader(file))
                                {
                                    var serializer = new JsonSerializer();
                                    postalCodesList = serializer.Deserialize<List<PostalCodesDTO>>(jsonTextReader);
                                }
                            }

                            var foundPostalCode = postalCodesList.FirstOrDefault(postalCode => postalCode.PostalCode == customerPostalCode);
                            if (foundPostalCode != null)
                            {
                                response.Result.MinimumTotalAmount = foundPostalCode.MinimumTotalAmount;
                                response.Success = response.Result.MinimumTotalAmount > default(int);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                response.Success = false;
            }
            return response;
        }

        private static decimal getMinimumFeeForVipUser(ResponseDTO<OrderDTO> orderResponse)
        {
            decimal minimumFee = default(decimal);
            if (orderResponse.Success && orderResponse.Result != null)
            {
                if(orderResponse.Result.Customer != null && !string.IsNullOrEmpty(orderResponse.Result.Customer.CustomerPhoneNumber))
                {
                    try
                    {
                        var vipList = new List<VipDiscountDTO>();
                        string customerPhoneNumber = orderResponse.Result.Customer.CustomerPhoneNumber;
                        using (StreamReader file = File.OpenText(HostingEnvironment.MapPath("~/assets/files/VipDiscountList.json")))
                        {
                            using (var jsonTextReader = new JsonTextReader(file))
                            {
                                var serializer = new JsonSerializer();
                                vipList = serializer.Deserialize<List<VipDiscountDTO>>(jsonTextReader);
                            }
                        }

                        var foundVipUser = vipList.FirstOrDefault(vipItem => vipItem.PhoneNumber == customerPhoneNumber);
                        if (foundVipUser != null)
                        {
                            minimumFee = foundVipUser.MinimumTotalAmount;
                        }
                    }
                    catch (Exception exception)
                    {
                        throw;
                    }
                }
            }
            return minimumFee;
        }
    }
}