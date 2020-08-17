namespace FoodApp.DataLayer
{
    using FoodApp.DataLayer.Extensions;
    using FoodApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.SqlClient;
    using System.Linq;

    public class DishesDataLayer
    {
        public List<DishComplementsDTO> DishComplementsGetFilteredList(long dishIdentifier, int dishSectionIdentifier)
        {
            var dishComplementsList = new List<DishComplementsDTO>();
            using(SqlCommand command = new SqlCommand("Usp_DishComplementsFiltered_GETL"))
            {
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = dishIdentifier;
                command.Parameters.Add("@DishSectionId", SqlDbType.Int).Value = dishSectionIdentifier;
                dishComplementsList = command.Select(reader => reader.ToDishComplements());
            }
            return dishComplementsList;
        }

        public List<DishesDTO> DishesByCategoryGetList(int categoryIdentifier)
        {
            var dishesList = new List<DishesDTO>();
            using(SqlCommand command = new SqlCommand("Usp_DishByCategory_GETL"))
            {
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryIdentifier;
                dishesList = command.Select(reader => reader.ToDishes());
            }
            return dishesList;
        }

        public List<DishSectionsDTO> DishSectionsByDishGetList(long dishIdentifier)
        {
            var dishSections = new List<DishSectionsDTO>();
            using(SqlCommand command = new SqlCommand("Usp_DishSectionsByDish_GETL"))
            {
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = dishIdentifier;
                dishSections = command.Select(reader => reader.ToDishSections());
            }
            return dishSections;
        }

        public bool DishesDelete(long dishIdentifier)
        {
            bool isExecuted = default;
            using(SqlCommand command = new SqlCommand("Usp_Dishes_DEL"))
            {
                command.Parameters.Add("@DishIdentifier", SqlDbType.BigInt).Value = dishIdentifier;
                isExecuted = command.ExecuteQuery();
            }
            return isExecuted;
        }

        public DishesDTO DishesGetItem(long dishIdentifier)
        {
            var dish = new DishesDTO();
            using (SqlCommand command = new SqlCommand("Usp_Dishes_GETI"))
            {
               command.Parameters.Add("@DishIdentifier", SqlDbType.BigInt).Value = dishIdentifier;
               dish = command.Select(reader => reader.ToDishes()).FirstOrDefault();
            }
            return dish;
        }

        public bool DishSectionUpdate(DishSectionsDTO dishSections)
        {
            bool isUpdated = default(bool);
            using (SqlCommand command = new SqlCommand("Usp_DishSections_UPD"))
            {
                command.Parameters.Add("@DishSectionId", SqlDbType.Int).Value = dishSections.DishSectionId;
                command.Parameters.Add("@DishSectionName", SqlDbType.VarChar).Value = dishSections.DishSectionName;
                isUpdated = command.ExecuteQuery();
            }
            return isUpdated;
        }

        public bool DishSectionCreate(DishesDTO item)
        {
            bool isSectionCreated = default(bool);
            using(SqlCommand command = new SqlCommand("Usp_DishSection_INS"))
            {
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = item.DishIdentifier;
                command.Parameters.Add("@DishSectionName", SqlDbType.VarChar).Value = item.DishSectionsList.FirstOrDefault().DishSectionName;
                isSectionCreated = command.ExecuteQuery();
            }
            return isSectionCreated;
        }

        public bool DishSectionDelete(int dishSectionIdentifier, long dishIdentifier)
        {
            bool isDishSectionDeleted = default(bool);
            using(SqlCommand command = new SqlCommand("Usp_DishSections_DEL"))
            {
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = dishIdentifier;
                command.Parameters.Add("@DishSectionId", SqlDbType.Int).Value = dishSectionIdentifier;
                isDishSectionDeleted = command.ExecuteQuery();
            }
            return isDishSectionDeleted;
        }

        public bool DishComplementsInsert(DishesDTO item)
        {
            bool isComplementCreated = default(bool);
            using(SqlCommand command = new SqlCommand("Usp_DishComplements_INS"))
            {
                var dishComplementItem = item.DishSectionsList.FirstOrDefault().DishComplementsList.FirstOrDefault();
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = item.DishIdentifier;
                command.Parameters.Add("@DishSectionId", SqlDbType.Int).Value = item.DishSectionsList.FirstOrDefault().DishSectionId;
                command.Parameters.Add("@DishComplementName", SqlDbType.VarChar).Value = dishComplementItem.DishComplementName;
                command.Parameters.Add("@IsIncludedInOrder", SqlDbType.Bit).Value = dishComplementItem.IsIncludedInOrder;
                command.Parameters.Add("@AditionalCost", SqlDbType.Decimal).Value = dishComplementItem.AditionalCost;
                isComplementCreated = command.ExecuteQuery();
            }
            return isComplementCreated;
        }

        public bool DishComplementsUpdate(int dishSectionIdentifier, long dishIdentifier, DishComplementsDTO dishComplementItem)
        {
            bool isComplementUpdated = default(bool);
            using (SqlCommand command = new SqlCommand("Usp_DishComplements_UPD"))
            {
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = dishIdentifier;
                command.Parameters.Add("@DishSectionId", SqlDbType.Int).Value = dishSectionIdentifier;
                command.Parameters.Add("@DishComplementId", SqlDbType.BigInt).Value = dishComplementItem.DishComplementId;
                command.Parameters.Add("@DishComplementName", SqlDbType.VarChar).Value = dishComplementItem.DishComplementName;
                command.Parameters.Add("@IsIncludedInOrder", SqlDbType.Bit).Value = dishComplementItem.IsIncludedInOrder;
                command.Parameters.Add("@AditionalCost", SqlDbType.Decimal).Value = dishComplementItem.AditionalCost;
                isComplementUpdated = command.ExecuteQuery();
            }
            return isComplementUpdated;
        }

        public bool DishComplementsDelete(long dishIdentifier, int dishSectionIndentifier, long dishComplementIdentifier)
        {
            bool isComplementDeleted = default(bool);
            using(SqlCommand command = new SqlCommand("Usp_DishComplements_DEL"))
            {
                command.Parameters.Add("@DishId", SqlDbType.BigInt).Value = dishIdentifier;
                command.Parameters.Add("@DishSectionId", SqlDbType.Int).Value = dishSectionIndentifier;
                command.Parameters.Add("@DishComplementId", SqlDbType.BigInt).Value = dishComplementIdentifier;
                isComplementDeleted = command.ExecuteQuery();
            }
            return isComplementDeleted;
        }
    }
}
