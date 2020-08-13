namespace FoodApp.Models
{
    public  class CustomersDTO : BaseDTO
    {
        public int CustomerIdentifier { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerPassword { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPostalCode { get; set; }

        public string CustomerAddress { get; set; }

    }
}
