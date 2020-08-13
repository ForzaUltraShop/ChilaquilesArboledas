namespace FoodApp.DataModels
{
    using FoodApp.Models;

    public class CategoriesDTO : BaseDTO
    {
        public int CategoryIdentifier { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public string CategoryImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}
