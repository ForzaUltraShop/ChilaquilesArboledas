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

        protected void bntLogin_Click(object sender, EventArgs e)
        {
            lblErrorLogin.Visible = false;
            if (string.IsNullOrWhiteSpace(txtUserPassword.Text.Trim()) || string.IsNullOrWhiteSpace(txtUserPassword.Text.Trim()))
            {
                lblErrorLogin.Text = "Número teléfonico y contraseña son necesarios para continuar";
                lblErrorLogin.Visible = true;
                return;
            }

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