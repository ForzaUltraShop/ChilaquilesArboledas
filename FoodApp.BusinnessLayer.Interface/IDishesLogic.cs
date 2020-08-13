namespace FoodApp.BusinnessLayer.Interface
{
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;

    public interface IDishesLogic
    {
        ResponseListDTO<DishesDTO> DishesByCategoryGetList(int categoryIdentifier);

        ResponseListDTO<DishSectionsDTO> DishSectionsByDishGetList(long dishIdentifier);

        ResponseListDTO<DishComplementsDTO> DishComplementsGetFilteredList(long dishIdentifier, int dishSectionIdentifier);

        ResponseDTO<DishesDTO> DishesExecute(RequestDTO<DishesDTO> filter);

        ResponseDTO<DishesDTO> DishesGetItem(RequestDTO<DishesDTO> filter);

        ResponseDTO<DishSectionsDTO> DishSectionExecute(RequestDTO<DishesDTO> filter);
    }
}
