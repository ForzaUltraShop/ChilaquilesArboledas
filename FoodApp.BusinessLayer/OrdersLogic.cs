using FoodApp.DataLayer;
using FoodApp.DataModels.Shared;
using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.BusinessLayer
{
    public class OrdersLogic
    {
        private readonly OrdersDataLayer ordersDataLayer = new OrdersDataLayer();

        public ResponseDTO<OrderDTO> OrderExecute(RequestDTO<OrderDTO> order)
        {
            var orderResponse = new ResponseDTO<OrderDTO> { Result = new OrderDTO() };
            try
            {
                switch (order.OperationType)
                {
                    case OperationType.Create:
                        orderResponse.Result.OrderIdentifier = ordersDataLayer.OrderCreate(order.Item);
                        orderResponse.Success = orderResponse.Result.OrderIdentifier > default(long);
                        break;
                    case OperationType.Update:
                        orderResponse.Result.OrderIdentifier = ordersDataLayer.OrderUpdate(order.Item);
                        orderResponse.Success = orderResponse.Result.OrderIdentifier > default(long);
                        break;
                }
            }
            catch (Exception exception)
            {
                orderResponse.Result = null;
            }
            return orderResponse;
        }

        public ResponseDTO<OrderDTO> OrderGetItem(long orderIdentifier)
        {
            var orderResponse = new ResponseDTO<OrderDTO>();
            try
            {
                orderResponse.Result = ordersDataLayer.OrderGetList(orderIdentifier).FirstOrDefault();
                orderResponse.Success = orderResponse.Result != null && orderResponse.Result.OrderIdentifier > default(long);
            }
            catch (Exception exception)
            {
                throw;
            }
            return orderResponse;
        }

        public ResponseDTO<OrderDTO> CartCheckOutExecute(RequestDTO<CartCheckOutDTO> cartCheckOutItem)
        {
            var response = new ResponseDTO<OrderDTO>();
            try
            {
                response.Success = ordersDataLayer.CartCheckOutExecute(cartCheckOutItem.Item.Order.OrderIdentifier, cartCheckOutItem.Item.AditionalCommnents, cartCheckOutItem.Item.DeliveryOption);
            }
            catch (Exception exception)
            {
                
            }
            return response;
        }
    }
}
