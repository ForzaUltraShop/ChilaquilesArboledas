using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FoodApp.DataLayer.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.DataLayer
{
    public class OrdersDataLayer
    {
        public bool OrderCreate(OrderDTO order)
        {
            bool orderCreated = default(bool);
            var dishComplementList = order.OrderDetailList.Select(x => x.DishComplementIdentifier);

            using (SqlCommand command = new SqlCommand("Usp_Order_INS"))
            {
                command.Parameters.Add("@CustomerId", System.Data.SqlDbType.BigInt).Value = order.Customer.CustomerIdentifier;
                command.Parameters.Add("@DishId", System.Data.SqlDbType.BigInt).Value = order.Dish.DishIdentifier;
                command.Parameters.Add("@ItemsCount", System.Data.SqlDbType.Int).Value = order.ItemsCount;
                command.Parameters.Add("@ComplementsList", System.Data.SqlDbType.VarChar).Value = string.Join(",", dishComplementList);
                orderCreated = command.ExecuteQuery();
            }
            return orderCreated;
        }
    }
}
