namespace FoodApp.DataLayer
{
    using FoodApp.DataLayer.Extensions;
    using FoodApp.Models;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class CustomerDataLayer
    {
        public bool CustomerExecute(CustomersDTO customer)
        {
            bool isExecuted = default;
            using(SqlCommand command = new SqlCommand("Usp_Customers_INS"))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = customer.CompanyIdentifier;
                command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = customer.CustomerName;
                command.Parameters.Add("@CustomerPhoneNumber", SqlDbType.VarChar).Value = customer.CustomerPhoneNumber;
                command.Parameters.Add("@CustomerEmail", SqlDbType.VarChar).Value = customer.CustomerEmail;
                command.Parameters.Add("@CustomerPassword", SqlDbType.VarChar).Value = customer.CustomerPassword;
                command.Parameters.Add("@CustomerPostalCode", SqlDbType.VarChar).Value = customer.CustomerPostalCode;
                command.Parameters.Add("@CustomerAddress", SqlDbType.VarChar).Value = customer.CustomerAddress;
                isExecuted = command.ExecuteQuery();
            }
            return isExecuted;
        }

        public CustomersDTO CustomerGetItem(string phoneNumber)
        {
            var customer = new CustomersDTO();
            using (SqlCommand command = new SqlCommand("Usp_Customers_GETI"))
            {
                command.Parameters.Add("@CustomerPhoneNumber", SqlDbType.VarChar).Value = phoneNumber;
                customer = command.Select(reader => reader.ToCustomer()).FirstOrDefault();
            }
            return customer;
        }
    }
}
