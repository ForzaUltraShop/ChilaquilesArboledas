using System.Collections.Generic;

namespace FoodApp.Models
{
    public class DishSectionsDTO
    {
        public int DishSectionId { get; set; }

        public string DishSectionName { get; set; }

        public int DishOrder { get; set; }

        public bool AllowMultipleOptions { get; set; }

        public bool IsActive { get; set; }

        public List<DishComplementsDTO> DishComplementsList { get; set; }
    }
}
