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
            var orderResponse = new ResponseDTO<OrderDTO>();
            try
            {
                switch (order.OperationType)
                {
                    case OperationType.Create:
                        orderResponse.Result.OrderIdentifier = ordersDataLayer.OrderCreate(order.Item);
                        orderResponse.Success = orderResponse.Result.OrderIdentifier > default(long);
                        break;
                }
            }
            catch (Exception exception)
            {
                throw;
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
    }
}
