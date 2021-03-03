using FoodApp.BusinessLayer.Helpers;
using FoodApp.DataLayer;
using FoodApp.DataModels;
using FoodApp.DataModels.Shared;
using FoodApp.Models;
using FoodApp.Models.Catalogs;
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
                orderResponse.Result = ordersDataLayer.OrderGetList(orderIdentifier).FirstOrDefault() ?? new OrderDTO();
                orderResponse.Result.OrderDetailList = orderDetailGetItem(orderIdentifier);
                orderResponse.Success = orderResponse.Result != null && orderResponse.Result.OrderIdentifier > default(long);
            }
            catch (Exception exception)
            {
                throw;
            }
            return orderResponse;
        }

        private List<OrderDetailDTO> orderDetailGetItem(long orderIdentifier)
        {
            var orderDetailList = new List<OrderDetailDTO>();
            try
            {
                orderDetailList = ordersDataLayer.OrderDetailGetList(orderIdentifier);
            }
            catch (Exception exception)
            {
                throw;
            }
            return orderDetailList;
        }

        public ResponseDTO<OrderDTO> CartCheckOutExecute(RequestDTO<CartCheckOutDTO> cartCheckOutItem)
        {
            var response = new ResponseDTO<OrderDTO>();
            try
            {
                response.Success = ordersDataLayer.CartCheckOutExecute
                (
                    cartCheckOutItem.Item.Order.OrderIdentifier,
                    cartCheckOutItem.Item.AditionalCommnents,
                    cartCheckOutItem.Item.DeliveryOption,
                    cartCheckOutItem.Item.Notify.Location.Latitude,
                    cartCheckOutItem.Item.Notify.Location.Longitude
                );

                if (response.Success)
                {
                    //Task.Run(() => 
                    sendNotify(cartCheckOutItem.Item.Order.OrderIdentifier,
                               cartCheckOutItem.Item.AditionalCommnents,
                               cartCheckOutItem.Item.DeliveryOption,
                               cartCheckOutItem.Item.Notify,
                               cartCheckOutItem.Item.CustomerAddress ?? string.Empty);

                    sendCustomerEmail(cartCheckOutItem.Item.Order.OrderIdentifier);

                    //));           
                }
            }
            catch (Exception exception)
            {

            }
            return response;
        }

        private void sendCustomerEmail(long orderIdentifier)
        {
            try
            {
                var orderItem = this.OrderGetItem(orderIdentifier);
                if (orderItem.Success)
                {
                    StringBuilder emailBody = new StringBuilder();
                    emailBody.AppendFormat(Resources.EmailResources.CustomerEmailBody,
                                           orderItem.Result.Customer.CustomerName,
                                           orderItem.Result.OrderIdentifier,
                                           Math.Round(orderItem.Result.ItemsTotalAmount, 2));

                    //Envio de correo electronico
                    new EmailHelper().SendEmail(new MailDTO
                    {
                        EmailBody = emailBody.ToString(),
                        EmailSubject = "Recibo de Chilaquiles Arboledas",
                        EmailTo = orderItem.Result.Customer.CustomerEmail
                    });
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void sendNotify(long orderIdentifier, string additionalComments, DeliveryOption deliveryOption, NotifyDTO notify, string customerAddress)
        {
            var notifyLogic = new NotifyLogic();
            try
            {
                var orderItem = this.OrderGetItem(orderIdentifier);
                StringBuilder sb = new StringBuilder("==============================\n");
                sb.AppendFormat("Se ha generado la orden <strong>#{0}</strong> a nombre de <strong>{1}</strong> \n\n", orderIdentifier, orderItem.Result.Customer.CustomerName);

                decimal orderTotalAmount = orderItem.Result.OrderDetailList.Sum(order => order.Quantity);

                var groupedList = orderItem.Result.OrderDetailList.GroupBy(g => g.UniqueKeyIdentifier).ToList();
                for (int i = 0; i < groupedList.Count(); i++)
                {
                    sb.AppendFormat("<strong>{0} {1}</strong>\n", groupedList[i].FirstOrDefault().Quantity, groupedList[i].FirstOrDefault().Dish.DishName);
                    foreach (var complement in groupedList[i])
                    {
                        sb.Append(complement.DishComplementName + "\n");
                    }
                    sb.Append("\n");
                }

                if (!string.IsNullOrEmpty(additionalComments.Trim()))
                {
                    sb.Append("-Comentarios adicionales:\n");
                    sb.Append(additionalComments + "\n\n");
                }

                switch (deliveryOption)
                {
                    case DeliveryOption.AtHome:
                        sb.Append("-Opción de Entrega: A domicilio\n");
                        if (!string.IsNullOrEmpty(customerAddress))
                        {
                            sb.Append("Dirección: " + customerAddress + "\n");
                        }
                        break;
                    case DeliveryOption.EatOnWay:
                        sb.Append("-Opción de Entrega: Para ir comiendo\n");
                        break;
                    case DeliveryOption.ToTake:
                        sb.Append("-Opción de Entrega: Para llevar\n");
                        break;
                }

                sb.Append($"-Total de la cuenta: ${ Math.Round(orderItem.Result.ItemsTotalAmount, 2) }\n");
                sb.Append("==============================\n");

                notify.Message = sb.ToString();
                notifyLogic.NotifyExecute(notify);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public ResponseDTO<bool> OrderDetailDelete(long orderIdentifier,string dishUniqueKey)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.Success = ordersDataLayer.OrderDetailDelete(orderIdentifier, dishUniqueKey);
            }
            catch (Exception ex)
            {
                response.Success = false;
            }
            return response;
        }
    }
}
