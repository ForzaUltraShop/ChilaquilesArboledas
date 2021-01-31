using FoodApp.BusinessLayer;
using FoodApp.DataModels.Shared;
using FoodApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChilaquilesArboledas.Forms
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TestPostalCode();
            GetMinimumFeeByOrder(44);
        }

        private void TestPostalCode()
        {
            try
            {
                var postalCodesList = new List<PostalCodesDTO>();
                string searchedPostalCode = "99999";

                using (StreamReader file = File.OpenText(Server.MapPath("~/assets/files/PostalCodes.json")))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        var serializer = new JsonSerializer();
                        postalCodesList = serializer.Deserialize<List<PostalCodesDTO>>(reader);
                    }
                }

                var foundPostalCode = postalCodesList.FirstOrDefault(postalCode => postalCode.PostalCode == searchedPostalCode);
                if(foundPostalCode != null)
                {
                    string a = $"encontrado {foundPostalCode.Municipality} con monto minimo de {foundPostalCode.MinimumTotalAmount}!";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ResponseDTO<PostalCodesDTO> GetMinimumFeeByOrder(long orderIdentifier)
        {
            var response = new ResponseDTO<PostalCodesDTO> { Result = new PostalCodesDTO() };
            try
            {
                var orderResponse = new OrdersLogic().OrderGetItem(orderIdentifier);
                if (orderResponse.Success)
                {
                    decimal orderTotalAmount = orderResponse.Result.ItemsTotalAmount;
                    if (orderTotalAmount > default(int))
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
            catch (Exception exception)
            {
                response.Success = false;
            }
            return response;
        }
    }
}