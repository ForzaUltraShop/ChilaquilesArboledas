namespace FoodApp.Models
{
    using Newtonsoft.Json;

    public class PostalCodesDTO
    {
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("MinimumTotalAmount")]
        public decimal MinimumTotalAmount { get; set; }

        [JsonProperty("Municipality")]
        public string Municipality { get; set; }

    }
}
