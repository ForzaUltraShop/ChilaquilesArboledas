namespace FoodApp.Models
{
    using System.Collections.Generic;

    public class DishesDTO
    {
        public long DishIdentifier { get; set; }

        public string DishName { get; set; }
        
        public string DishDescription { get; set; }

        public decimal DishPrice { get; set; }

        public string DishImagePath { get; set; }

        public bool IsActive { get; set; }

        public List<DishSectionsDTO> DishSectionsList { get; set; }
    }
}
