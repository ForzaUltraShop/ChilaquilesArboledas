namespace FoodApp.DataLayer.Interface
{
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using System.Collections.Generic;

    public interface ICategoriesDataLayer
    {
        bool CategoryCreate(CategoriesDTO category);

        bool CategoryDelete(int categoryIdentifier);

        bool CategoryUpdate(CategoriesDTO category);

        List<CategoriesDTO> CategoriesGetFilteredList(RequestDTO<CategoriesDTO> categoriesFilter);
    }
}