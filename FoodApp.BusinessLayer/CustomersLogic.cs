using FoodApp.BusinnessLayer.Interface;
using FoodApp.DataLayer;
using FoodApp.DataLayer.Interface;
using FoodApp.DataModels.Shared;
using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.BusinessLayer
{
    public class CustomersLogic : ICustomerLogic
    {
        private readonly ICustomerDataLayer customerDataLayer;

        public CustomersLogic()
        {

        }

        public CustomersLogic(ICustomerDataLayer customerDataLayer)
        {
            this.customerDataLayer = customerDataLayer;
        }

        public ResponseDTO<CustomersDTO> CustomerExecute(RequestDTO<CustomersDTO> customer)
        {
            var customerResponse = new ResponseDTO<CustomersDTO>();
            try
            {
                customerResponse.Success = new CustomerDataLayer().CustomerExecute(customer.Item);
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
