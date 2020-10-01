namespace FoodApp.BusinessLayer
{
    using FoodApp.DataLayer;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DishesLogic
    {
        /// <summary>
        /// Interface de acceso a datos
        /// </summary>
        private readonly DishesDataLayer dishesDataLayer = new DishesDataLayer();

        /// <summary>
        /// Permite establecer el identificador de la categoria a la que pertenece el platillo
        /// </summary>
        public int CategoryIdentifier { get; set; }

        public ResponseDTO<DishesDTO> DishesExecute(RequestDTO<DishesDTO> filter)
        {
            var response = new ResponseDTO<DishesDTO>();
            try
            {
                switch (filter.OperationType)
                {
                    case OperationType.Create:
                        response.Result = dishesDataLayer.DishesCreate(CategoryIdentifier, filter.Item);
                        response.Success = response.Result?.DishIdentifier > default(long);
                        break;
                    case OperationType.Delete:
                        response.Success = dishesDataLayer.DishesDelete(filter.Item.DishIdentifier);
                        break;
                    case OperationType.Update:
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
        /// Obtiene un listado de complementos por platillo y seccion
        /// </summary>
        /// <param name="dishIdentifier"></param>
        /// <param name="dishSectionIdentifier"></param>
        /// <returns></returns>
        public ResponseListDTO<DishComplementsDTO> DishComplementsGetFilteredList(long dishIdentifier, int dishSectionIdentifier)
        {
            var dishComplementsResponse = new ResponseListDTO<DishComplementsDTO> { Result = new List<DishComplementsDTO>() };
            try
            {
                dishComplementsResponse.Result = dishesDataLayer.DishComplementsGetFilteredList(dishIdentifier, dishSectionIdentifier);
                dishComplementsResponse.Success = dishComplementsResponse.Result.Any();
            }
            catch (Exception exception)
            {
                throw;
            }
            return dishComplementsResponse;
        }

        /// <summary>
        /// Permite obtener listado de platillos por categoría
        /// </summary>
        /// <param name="categoryIdentifier"></param>
        /// <returns></returns>
        public ResponseListDTO<DishesDTO> DishesByCategoryGetList(int categoryIdentifier)
        {
            var dishesByCategoryResponse = new ResponseListDTO<DishesDTO>();
            try
            {
                dishesByCategoryResponse.Result = dishesDataLayer.DishesByCategoryGetList(categoryIdentifier);
                dishesByCategoryResponse.Success = dishesByCategoryResponse.Result.Any();
            }
            catch (Exception exception)
            {
                throw;
            }
            return dishesByCategoryResponse;
        }

        /// <summary>
        /// Obtiene el listado de secciones por platillo
        /// </summary>
        /// <param name="dishIdentifier"></param>
        /// <returns></returns>
        public ResponseListDTO<DishSectionsDTO> DishSectionsByDishGetList(long dishIdentifier)
        {
            var dishSectionsResponse = new ResponseListDTO<DishSectionsDTO>();
            try
            {
                dishSectionsResponse.Result = dishesDataLayer.DishSectionsByDishGetList(dishIdentifier);
                dishSectionsResponse.Success = dishSectionsResponse.Result.Any();
            }
            catch (Exception)
            {
                throw;
            }
            return dishSectionsResponse;
        }

        public ResponseDTO<DishesDTO> DishesGetItem(RequestDTO<DishesDTO> filter)
        {
            var dishResponse = new ResponseDTO<DishesDTO>();
            try
            {
                dishResponse.Result = dishesDataLayer.DishesGetItem(filter.Item.DishIdentifier);
                dishResponse.Success = dishResponse.Result != null && dishResponse.Result?.DishIdentifier > default(long);
            }
            catch (Exception exception)
            {
                throw;
            }
            return dishResponse;
        }

        public ResponseDTO<DishSectionsDTO> DishSectionExecute(RequestDTO<DishesDTO> filter)
        {
            var dishSectionResponse = new ResponseDTO<DishSectionsDTO>();
            try
            {
                switch (filter.OperationType)
                {
                    case OperationType.Update:
                        dishSectionResponse.Success = dishesDataLayer.DishSectionUpdate(filter.Item.DishSectionsList.FirstOrDefault());
                        break;
                    case OperationType.Create:
                        dishSectionResponse.Success = dishesDataLayer.DishSectionCreate(filter.Item);
                            break;
                    case OperationType.Delete:
                        dishSectionResponse.Success = dishesDataLayer.DishSectionDelete(filter.Item.DishSectionsList.FirstOrDefault().DishSectionId, filter.Item.DishIdentifier);
                        break;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return dishSectionResponse;
        }

        public ResponseListDTO<DishComplementsDTO> DishComplementsGetFilteredList(RequestDTO<DishesDTO> filter)
        {
            var dishComplementsResponse = new ResponseListDTO<DishComplementsDTO>();
            try
            {
                dishComplementsResponse.Result = dishesDataLayer.DishComplementsGetFilteredList(filter.Item.DishIdentifier, filter.Item.DishSectionsList.FirstOrDefault().DishSectionId);
                dishComplementsResponse.Success = dishComplementsResponse.Result != null && dishComplementsResponse.Result.Any();
            }
            catch (Exception exception)
            {
                throw;
            }
            return dishComplementsResponse;
        }

        public ResponseDTO<DishComplementsDTO> DishComplementsExecute(RequestDTO<DishesDTO> filter)
        {
            var response = new ResponseDTO<DishComplementsDTO>();
            try
            {
                var dishComplementItem = filter.Item.DishSectionsList.FirstOrDefault().DishComplementsList.FirstOrDefault();
                switch (filter.OperationType)
                {
                    case OperationType.Create:
                        response.Success = dishesDataLayer.DishComplementsInsert(filter.Item);
                        break;
                    case OperationType.Update:
                        response.Success = dishesDataLayer.DishComplementsUpdate(filter.Item.DishSectionsList.FirstOrDefault().DishSectionId,
                                                                                 filter.Item.DishIdentifier,
                                                                                 dishComplementItem);
                        break;
                    case OperationType.Delete:
                        response.Success = dishesDataLayer.DishComplementsDelete(filter.Item.DishIdentifier,
                                                                                 filter.Item.DishSectionsList.FirstOrDefault().DishSectionId,
                                                                                 dishComplementItem.DishComplementId);
                        break;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return response;
        }
    }
}