namespace FoodApp.BusinessLayer
{
    using FoodApp.BusinnessLayer.Interface;
    using FoodApp.DataLayer.Interface;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using System;
    using System.Linq;

    public class CategoriesLogic : ICategoriesLogic
    {
        private readonly ICategoriesDataLayer categoriesDataLayer;

        public CategoriesLogic(ICategoriesDataLayer categoriesDataLayer)
        {
            this.categoriesDataLayer = categoriesDataLayer;
        }

        public ResponseDTO<CategoriesDTO> CategoriesExecute(RequestDTO<CategoriesDTO> filter)
        {
            var response = new ResponseDTO<CategoriesDTO>();
            try
            {
                switch (filter.OperationType)
                {
                    case OperationType.Delete:
                        response.Success = deleteCategory(filter.Item.CategoryIdentifier);
                        break;
                    case OperationType.Create:
                        response.Success = createCategory(filter.Item);
                        break;
                    case OperationType.Update:
                        response.Success = updateCategory(filter.Item);
                        break;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return response;
        }

        /// <summary>
        /// Permite actualizar una categoria existente
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool updateCategory(CategoriesDTO item)
        {
            return categoriesDataLayer.CategoryUpdate(item);
        }

        /// <summary>
        /// Permite agregar una nueva categoria
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool createCategory(CategoriesDTO item)
        {
            return categoriesDataLayer.CategoryCreate(item);
        }

        /// <summary>
        /// Permite eliminar un registro de categoria
        /// </summary>
        /// <param name="categoryIdentifier"></param>
        private bool deleteCategory(int categoryIdentifier)
        {
            return categoriesDataLayer.CategoryDelete(categoryIdentifier);
        }

        /// <summary>
        /// Obtiene el listado de categorias disponibles
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ResponseListDTO<CategoriesDTO> CategoriesGetFilteredList(RequestDTO<CategoriesDTO> filter)
        {
            var response = new ResponseListDTO<CategoriesDTO>();
            try
            {
                response.Result = categoriesDataLayer.CategoriesGetFilteredList(filter);
                response.Success = response.Result.Any();
            }
            catch (Exception exception)
            {
                throw;
            }
            return response;
        }
    }
}
