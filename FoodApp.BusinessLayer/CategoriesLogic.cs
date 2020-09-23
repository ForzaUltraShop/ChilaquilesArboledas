namespace FoodApp.BusinessLayer
{
    using FoodApp.DataLayer;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using FoodApp.Models;
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class CategoriesLogic
    {
        private readonly CategoriesDataLayer categoriesDataLayer = new CategoriesDataLayer();

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

        /// <summary>
        /// Obtiene datos de la categoria relacionada con el identificador del platillo
        /// </summary>
        /// <param name="dishIdentifier"></param>
        /// <returns></returns>
        public ResponseDTO<CategoriesDTO> CategoryByDishIdentifierGetItem(long dishIdentifier)
        {
            var dishCategoryResponse = new ResponseDTO<CategoriesDTO>();
            try
            {
                CategoriesDTO category = categoriesDataLayer.CategoryByDishIdentifierGetItem(dishIdentifier);
                DishesDTO dishItem = new DishesDTO();
                
                if(category.CategoryIdentifier > default(long))
                {
                    dishItem = new DishesLogic().DishesGetItem(new RequestDTO<DishesDTO>
                    {
                        Item = new DishesDTO
                        {
                            DishIdentifier = dishIdentifier
                        }
                    }).Result;

                    var dishSectionsList = new DishesLogic().DishSectionsByDishGetList(dishIdentifier);
                    if (dishSectionsList.Success)
                    {
                        dishSectionsList.Result = dishSectionsList.Result.Where(dish => dish.IsActive).ToList();
                        for (int i = 0; i < dishSectionsList.Result.Count; i++)
                        {
                            var dishSectionComplements = new DishesLogic().DishComplementsGetFilteredList(new RequestDTO<DishesDTO>
                            {
                                Item = new DishesDTO
                                {
                                    DishIdentifier = dishIdentifier,
                                    DishSectionsList = new List<DishSectionsDTO>
                                    {
                                        new DishSectionsDTO
                                        {
                                            DishSectionId = dishSectionsList.Result[i].DishSectionId
                                        }
                                    }
                                }
                            });

                            if (dishSectionComplements.Success)
                            {
                                //Agrego los complementos a cada una de la secciones
                                dishSectionsList.Result[i].DishComplementsList = new List<DishComplementsDTO>();
                                dishSectionsList.Result[i].DishComplementsList.AddRange(dishSectionComplements.Result);
                            }
                        }

                        //Agrego las secciones al item del platillo
                        dishItem.DishSectionsList = new List<DishSectionsDTO>();
                        dishItem.DishSectionsList.AddRange(dishSectionsList.Result);
                    }

                    //Agrego el platillo a la categoria
                    category.DishesList = new List<DishesDTO>();
                    category.DishesList.Add(dishItem);

                    dishCategoryResponse.Result = category;
                    if(category.CategoryIdentifier > default(long) && 
                        (category.DishesList != null & category.DishesList.Any()) && 
                        (category.DishesList.FirstOrDefault().DishSectionsList != null && category.DishesList.FirstOrDefault().DishSectionsList.Any())) {
                        dishCategoryResponse.Success = true;
                    }
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return dishCategoryResponse;
        }
    }
}
