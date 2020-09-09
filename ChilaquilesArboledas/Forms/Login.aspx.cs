namespace ChilaquilesArboledas.Forms
{
    using FoodApp.BusinessLayer;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using FoodApp.Models.Catalogs;
    using System;
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
            var newCustomerLogic = new CustomersLogic();
            var response = newCustomerLogic.CustomerExecute(new RequestDTO<CustomersDTO> { Item = customer });
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