
namespace FoodApp.DataLayer
{
    using FoodApp.DataLayer.Extensions;
    using FoodApp.DataModels;
    using FoodApp.DataModels.Shared;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class CategoriesDataLayer
    {
        public List<CategoriesDTO> CategoriesGetFilteredList(RequestDTO<CategoriesDTO> categoriesFilter)
        {
            var categoriesList = new List<CategoriesDTO>();
            using (SqlCommand command = new SqlCommand("Usp_CategoriesGetFilteredList"))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.VarChar).Value = categoriesFilter.Item.CompanyIdentifier;
                command.Parameters.Add("@CategoryId", SqlDbType.VarChar).Value = categoriesFilter.Item.CategoryIdentifier;
                command.Parameters.Add("@WordFilter", SqlDbType.VarChar).Value = categoriesFilter.WordFilter ?? string.Empty;
                categoriesList = command.Select(reader => reader.ToCategory());
            }
            return categoriesList;
        }

        public bool CategoryCreate(CategoriesDTO category)
        {
            bool isCreated = default;
            using(SqlCommand command = new SqlCommand("Usp_CategoryItem_INS"))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = category.CompanyIdentifier;
                command.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = category.CategoryName;
                command.Parameters.Add("@CategoryDescription", SqlDbType.VarChar).Value = category.CategoryDescription;
                command.Parameters.Add("@CategoryImagePath", SqlDbType.VarChar).Value = category.CategoryImagePath;
                isCreated = command.ExecuteQuery();
            }
            return isCreated;
        }

        public bool CategoryDelete(int categoryIdentifier)
        {
            bool isDeleted = default;
            using(SqlCommand command = new SqlCommand("Usp_CategoryItem_DEL"))
            {
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryIdentifier;
                isDeleted = command.ExecuteQuery();
            }
            return isDeleted;
        }

        public bool CategoryUpdate(CategoriesDTO category)
        {
            bool isUpdated = default;
            using (SqlCommand command = new SqlCommand("Usp_CategoryItem_UPD"))
            {
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = category.CategoryIdentifier;
                command.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = category.CategoryName;
                command.Parameters.Add("@CategoryDescription", SqlDbType.VarChar).Value = category.CategoryDescription;
                command.Parameters.Add("@CategoryImagePath", SqlDbType.VarChar).Value = category.CategoryImagePath;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = category.IsActive;
                isUpdated = command.ExecuteQuery();
            }
            return isUpdated;
        }

        public CategoriesDTO CategoryByDishIdentifierGetItem(long dishIdentifier)
        {
            var category = new CategoriesDTO();
            using(SqlCommand command = new SqlCommand("Usp_CategoryByDishId_GETI"))
            {
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = dishIdentifier;
                category = command.Select(reader => reader.ToCategory()).FirstOrDefault();
            }
            return category;
        }
    }
}
