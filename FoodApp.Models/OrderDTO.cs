namespace FoodApp.Models
{
    using FoodApp.Models.Catalogs;
    using System.Collections.Generic;

    public class OrderDTO
    {
        public long OrderIdentifier { get; set; }

        public CustomersDTO Customer { get; set; }

        public int ItemsCount { get; set; }

        public decimal ItemsTotalAmount { get; set; }

        public List<OrderDetailDTO> OrderDetailList { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }

    public class OrderDetailDTO
    {
        public long OrderDetailIdentifier { get; set; }

        public DishesDTO Dish { get; set; }

        public long DishComplementIdentifier { get; set; }

        public string DishComplementName { get; set; }

        public decimal AditionalCost { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
