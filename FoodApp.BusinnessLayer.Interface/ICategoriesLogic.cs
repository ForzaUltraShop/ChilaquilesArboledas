namespace FoodApp.BusinnessLayer.Interface
{
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;

    public interface ICategoriesLogic
    {
        ResponseListDTO<CategoriesDTO> CategoriesGetFilteredList(RequestDTO<CategoriesDTO> filter);

        ResponseDTO<CategoriesDTO> CategoriesExecute(RequestDTO<CategoriesDTO> filter);
    }
}