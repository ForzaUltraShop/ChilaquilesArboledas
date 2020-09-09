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
                        orderResponse.Success = ordersDataLayer.OrderCreate(order.Item);
                        break;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return orderResponse;
        }
    }
}
