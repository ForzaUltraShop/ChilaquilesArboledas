namespace FoodApp.Models
{
    using FoodApp.DataModels;
    using FoodApp.Models.Catalogs;

    public class CartCheckOutDTO
    {
        public OrderDTO Order { get; set; }

        public string AditionalCommnents { get; set; }

        public DeliveryOption DeliveryOption { get; set; }

        public NotifyDTO Notify { get; set; }
    }
}
