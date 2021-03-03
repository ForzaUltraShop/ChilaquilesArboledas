namespace ChilaquilesArboledas.Forms
{
    using FoodApp.BusinessLayer;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using FoodApp.Models.Catalogs;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Web.UI;

    public partial class Login : Page
    {
        private readonly CustomersLogic customerLogic = new CustomersLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        [WebMethod()]
        public static ResponseDTO<CustomersDTO> RegisterCustomer(CustomersDTO customer)
        {
            var response = new ResponseDTO<CustomersDTO>();
            try
            {
                var postalCodesList = new List<PostalCodesDTO>();
                string searchedPostalCode = customer.CustomerPostalCode;

                using (StreamReader file = File.OpenText(HostingEnvironment.MapPath("~/assets/files/PostalCodes.json")))
                {
                    using (var jsonTextReader = new JsonTextReader(file))
                    {
                        var serializer = new JsonSerializer();
                        postalCodesList = serializer.Deserialize<List<PostalCodesDTO>>(jsonTextReader);
                    }
                }

                var foundPostalCode = postalCodesList.FirstOrDefault(postalCode => postalCode.PostalCode == searchedPostalCode);
                if (foundPostalCode != null)
                {
                    var newCustomerLogic = new CustomersLogic();
                    response = newCustomerLogic.CustomerExecute(new RequestDTO<CustomersDTO> { Item = customer });
                }
                else
                {
                    response.ErrorMessage = "WrongPostalCode";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ResponseListDTO<PostalCodesDTO> PostalCodeGetList()
        {
            var responsePostalCodes = new ResponseListDTO<PostalCodesDTO> { Result = new List<PostalCodesDTO>() };
            try
            {
                using (StreamReader file = File.OpenText(HostingEnvironment.MapPath("~/assets/files/PostalCodes.json")))
                {
                    using (var jsonTextReader = new JsonTextReader(file))
                    {
                        var serializer = new JsonSerializer();
                        responsePostalCodes.Result = serializer.Deserialize<List<PostalCodesDTO>>(jsonTextReader);
                        responsePostalCodes.Success = responsePostalCodes.Result.Any();
                    }
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return responsePostalCodes;
        }

        protected void bntLogin_Click(object sender, EventArgs e)
        {
            lblErrorLogin.Visible = false;
            lblErrorLogin.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtUserPassword.Text.Trim()) || string.IsNullOrWhiteSpace(txtUserPassword.Text.Trim()))
            {
                lblErrorLogin.Text = "Número teléfonico y contraseña son necesarios para continuar";
                lblErrorLogin.Visible = true;
                return;
            }

            TimeZoneInfo setTimeZoneInfo;
            DateTime currentDateTime;

            //Set the time zone information to US Mountain Standard Time 
            setTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");

            //Get date and time in US Mountain Standard Time
            currentDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, setTimeZoneInfo);


            bool isAvailableTime = default(bool);
            TimeSpan start;
            TimeSpan end;
            TimeSpan now = currentDateTime.TimeOfDay;

            switch (currentDateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                    isAvailableTime = false;
                    break;
                case DayOfWeek.Thursday:
                    start = TimeSpan.Parse("08:00");
                    end = TimeSpan.Parse("15:00");
                    isAvailableTime = (now >= start && now <= end);
                    break;
                case DayOfWeek.Friday:
                    start = TimeSpan.Parse("08:00");
                    end = TimeSpan.Parse("17:00");
                    isAvailableTime = (now >= start && now <= end);
                    break;
                case DayOfWeek.Saturday:
                    start = TimeSpan.Parse("09:00");
                    end = TimeSpan.Parse("17:00");
                    isAvailableTime = (now >= start && now <= end);
                    break;
                case DayOfWeek.Sunday:
                    start = TimeSpan.Parse("09:00");
                    end = TimeSpan.Parse("15:00");
                    isAvailableTime = (now >= start && now <= end);
                    break;
                default:
                    break;
            }

            //if (!isAvailableTime)
            //{
            //    lblErrorLogin.Text = "No contamos con servicio en este horario";
            //    lblErrorLogin.Visible = true;
            //    return;
            //}

            var customerResponse = customerLogic.CustomerGetItem(new RequestDTO<CustomersDTO>
            {
                Item = new CustomersDTO
                {
                    CustomerPhoneNumber = txtUserPhoneNumber.Text.Trim()
                }
            });

            if (customerResponse.Success)
            {
                if(customerResponse.Result.CustomerPassword == txtUserPassword.Text.Trim())
                {
                    Session["CustomerId"] = customerResponse.Result.CustomerIdentifier;
                    Session["CustomerName"] = customerResponse.Result.CustomerName;
                    Session["CustomerAddress"] = customerResponse.Result.CustomerAddress;
                    
                    if (customerResponse.Result.CustomerRole == (int)CustomerRole.Customer)
                    {
                        Response.Redirect("~/Forms/Menu.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Forms/Admin/Categories.aspx");
                    }
                }
                else
                {
                    lblErrorLogin.Text = "Número teléfonico o contraseña no validos";
                    lblErrorLogin.Visible = true;
                }
            }
            else
            {
                lblErrorLogin.Text = "No se encontró registro de este número teléfonico, te invitamos a registrarte gratuitamente.";
                lblErrorLogin.Visible = true;
            }
        }
    }
}