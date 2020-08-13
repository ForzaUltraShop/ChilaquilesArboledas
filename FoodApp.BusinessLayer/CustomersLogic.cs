namespace FoodApp.BusinessLayer
{
    using FoodApp.DataLayer;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomersLogic
    {
        private readonly CustomerDataLayer customerDataLayer = new CustomerDataLayer();

        public ResponseDTO<CustomersDTO> CustomerExecute(RequestDTO<CustomersDTO> customer)
        {
            var customerResponse = new ResponseDTO<CustomersDTO>();
            try
            {
                customerResponse.Success = customerDataLayer.CustomerExecute(customer.Item);
            }
            catch (Exception exception)
            {
                throw;
            }
            return customerResponse;
        }

        public ResponseDTO<CustomersDTO> CustomerGetItem(RequestDTO<CustomersDTO> customer)
        {
            var customerResponse = new ResponseDTO<CustomersDTO>();
            try
            {
                customerResponse.Result = customerDataLayer.CustomerGetItem(customer.Item.CustomerPhoneNumber);
                customerResponse.Success = customerResponse.Result?.CustomerIdentifier > default(int);
            }
            catch (Exception exception)
            {
                throw;
            }
            return customerResponse;
        }
    }
}
