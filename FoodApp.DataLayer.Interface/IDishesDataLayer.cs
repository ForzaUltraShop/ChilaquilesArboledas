namespace FoodApp.DataLayer.Interface
{
    using FoodApp.Models;
    using System.Collections.Generic;

    public interface IDishesDataLayer
    {
        List<DishesDTO> DishesByCategoryGetList(int categoryIdentifier);

        List<DishSectionsDTO> DishSectionsByDishGetList(long dishIdentifier);

        List<DishComplementsDTO> DishComplementsGetFilteredList(long dishIdentifier, int dishSectionIdentifier);

        bool DishesDelete(long dishIdentifier);

        DishesDTO DishesGetItem(long dishIdentifier);

        bool DishSectionUpdate(DishSectionsDTO dishSections);

        bool DishSectionCreate(DishesDTO item);
        
    }
}
