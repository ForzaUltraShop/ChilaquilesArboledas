﻿namespace FoodApp.DataLayer
{
    using FoodApp.DataLayer.Extensions;
    using FoodApp.Models;
    using FoodApp.Models.Catalogs;
    using System;
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
                command.Parameters.Add("@DishUniqueKey", System.Data.SqlDbType.VarChar).Value = Guid.NewGuid().ToString();
                orderIdentifier = command.Select(reader => reader.ToOrder()).FirstOrDefault().OrderIdentifier;
            }
            return orderIdentifier;
        }

        public long OrderUpdate(OrderDTO order)
        {
            long orderIdentifier = default(long);
            var dishComplementList = order.OrderDetailList.Select(x => x.DishComplementIdentifier);

            using (SqlCommand command = new SqlCommand("Usp_Order_UPD"))
            {
                command.Parameters.Add("@CustomerId", System.Data.SqlDbType.BigInt).Value = order.Customer.CustomerIdentifier;
                command.Parameters.Add("@OrderId", System.Data.SqlDbType.BigInt).Value = order.OrderIdentifier;
                command.Parameters.Add("@DishId", System.Data.SqlDbType.BigInt).Value = order.OrderDetailList.FirstOrDefault().Dish.DishIdentifier;
                command.Parameters.Add("@ItemsCount", System.Data.SqlDbType.Int).Value = order.ItemsCount;
                command.Parameters.Add("@ComplementsList", System.Data.SqlDbType.VarChar).Value = string.Join(",", dishComplementList);
                command.Parameters.Add("@DishUniqueKey", System.Data.SqlDbType.VarChar).Value = Guid.NewGuid().ToString();
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

        public List<OrderDetailDTO> OrderDetailGetList(long orderIdentifier)
        {
            var orderList = new List<OrderDetailDTO>();
            using (SqlCommand command = new SqlCommand("Usp_Orders_GETI"))
            {
                command.Parameters.Add("@OrderId", System.Data.SqlDbType.BigInt).Value = orderIdentifier;
                orderList = command.Select(reader => reader.ToOrderDetail());
            }
            return orderList;
        }

        public bool CartCheckOutExecute(long orderIdentifier, string aditionalComments, DeliveryOption deliveryOption, string latitude, string longitude)
        {
            bool isCartCheckOutExecuted = default(bool);
            using(SqlCommand command = new SqlCommand("Usp_OrderCheckOut_INS"))
            {
                command.Parameters.Add("@OrderId", System.Data.SqlDbType.BigInt).Value = orderIdentifier;
                command.Parameters.Add("@AditionalComments", System.Data.SqlDbType.VarChar).Value = aditionalComments;
                command.Parameters.Add("@DeliveryOption", System.Data.SqlDbType.SmallInt).Value = (int)deliveryOption;
                command.Parameters.Add("@Latitude", System.Data.SqlDbType.VarChar).Value = latitude;
                command.Parameters.Add("@Longitude", System.Data.SqlDbType.VarChar).Value = longitude;
                isCartCheckOutExecuted = command.ExecuteQuery();
            }
            return isCartCheckOutExecuted;
        }

        public bool OrderDetailDelete(long orderIdentifier,string dishUniqueKey)
        {
            using(SqlCommand command = new SqlCommand("Usp_OrderDetail_DEL"))
            {
                command.Parameters.Add("@OrderId", System.Data.SqlDbType.BigInt).Value = orderIdentifier;
                command.Parameters.Add("@DishUniqueKey", System.Data.SqlDbType.VarChar).Value = dishUniqueKey;

                return command.ExecuteQuery();
            }
        }
    }
}
