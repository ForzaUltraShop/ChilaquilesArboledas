using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.DataLayer.Interface
{
    public interface ICustomerDataLayer
    {
        bool CustomerExecute(CustomersDTO customer);

        CustomersDTO CustomerGetItem(string phoneNumber);
    }
}
