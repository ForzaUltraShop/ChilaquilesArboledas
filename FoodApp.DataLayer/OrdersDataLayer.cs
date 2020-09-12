namespace FoodApp.DataLayer
{
    using FoodApp.DataLayer.Extensions;
    using FoodApp.Models;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class OrdersDataLayer
    {
        public long OrderCreate(OrderDTO order)
        {
            long orderIdentifier = default(long);
            var dishComplementList = order.OrderDetailList.Select(x => x.DishComplementIdentifier);

            using (SqlCommand command = new SqlCommand("Usp_Order_INS"))
            {
                command.Parameters.Add("@CustomerId", System.Data.SqlDbType.BigInt).Value = order.Customer.CustomerIdentifier;
                command.Parameters.Add("@DishId", System.Data.SqlDbType.BigInt).Value = order.OrderDetailList.FirstOrDefault().Dish.DishIdentifier;
                command.Parameters.Add("@ItemsCount", System.Data.SqlDbType.Int).Value = order.ItemsCount;
                command.Parameters.Add("@ComplementsList", System.Data.SqlDbType.VarChar).Value = string.Join(",", dishComplementList);
                orderIdentifier = command.Select(reader => reader.ToOrder()).FirstOrDefault().OrderIdentifier;
            }
            return orderIdentifier;
        }

        public List<OrderDTO> OrderGetList(long orderIdentifier)
        {
            var orderList = new List<OrderDTO>();
            using(SqlCommand command = new SqlCommand("Usp_Orders_GETI"))
            {
                command.Parameters.Add("@OrderId", System.Data.SqlDbType.BigInt).Value = orderIdentifier;
                orderList = command.Select(reader => reader.ToOrder());
            }
            return orderList;
        }
    }
}
