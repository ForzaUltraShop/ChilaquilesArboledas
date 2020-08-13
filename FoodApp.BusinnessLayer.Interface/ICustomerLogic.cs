using FoodApp.DataModels.Shared;
using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.BusinnessLayer.Interface
{
    public interface ICustomerLogic
    {
        ResponseDTO<CustomersDTO> CustomerExecute(RequestDTO<CustomersDTO> customer);

        ResponseDTO<CustomersDTO> CustomerGetItem(RequestDTO<CustomersDTO> customer);

    }
}
