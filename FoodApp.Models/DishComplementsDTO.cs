namespace FoodApp.Models
{
    public class DishComplementsDTO
    {
        public long DishComplementId { get; set; }
        
        public string DishComplementName { get; set; }
        
        public bool IsIncludedInOrder { get; set; }
        
        public decimal AditionalCost { get; set; }
        
        public int DishComplementOrder { get; set; }
        
        public bool IsActive { get; set; }
    }
}
