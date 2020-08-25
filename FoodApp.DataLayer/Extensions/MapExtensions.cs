namespace FoodApp.DataLayer.Extensions
{
    using FoodApp.DataModels;
    using FoodApp.Models;
    using System.Data;

    public static class MapExtensions
    {
        public static CategoriesDTO ToCategory(this IDataReader reader)
        {
            return new CategoriesDTO
            {
                CategoryIdentifier = reader.Get<int>("CategoryId"),
                CategoryName = reader.Get<string>("CategoryName"),
                CategoryDescription = reader.Get<string>("CategoryDescription"),
                CategoryImagePath = reader.Get<string>("CategoryImagePath"),
                IsActive = reader.Get<bool>("IsActive")
            };
        }

        public static DishesDTO ToDishes(this IDataReader reader)
        {
            return new DishesDTO
            {
                DishIdentifier = reader.Get<long>("DishId"),
                DishName = reader.Get<string>("DishName"),
                DishDescription = reader.Get<string>("DishDescription"),
                DishImagePath = reader.Get<string>("DishImagePath"),
                DishPrice = reader.Get<decimal>("DishPrice"),
                IsActive = reader.Get<bool>("IsActive")
            };
        }

        public static DishSectionsDTO ToDishSections(this IDataReader reader)
        {
            return new DishSectionsDTO
            {
                DishSectionId = reader.Get<int>("DishSectionId"),
                DishSectionName = reader.Get<string>("DishSectionName"),
                DishOrder = reader.Get <int>("DishOrder"),
                AllowMultipleOptions = reader.Get<bool>("AllowMultipleOption"),
                IsActive = reader.Get<bool>("IsActive")
            };
        }

        public static DishComplementsDTO ToDishComplements(this IDataReader reader)
        {
            return new DishComplementsDTO
            {
                DishComplementId = reader.Get<long>("DishComplementId"),
                DishComplementName = reader.Get<string>("DishComplementName"),
                AditionalCost = reader.Get<decimal>("AditionalCost"),
                IsIncludedInOrder = reader.Get<bool>("IsIncludedInOrder"),
                DishComplementOrder = reader.Get<int>("DishComplementOrder"),
                IsActive = reader.Get<bool>("IsActive")
            };
        }

        public static CustomersDTO ToCustomer(this IDataReader reader)
        {
            return new CustomersDTO
            {
                CustomerIdentifier = reader.Get<int>("CustomerId"),
                CustomerName = reader.Get<string>("CustomerName"),
                CustomerPhoneNumber = reader.Get<string>("CustomerPhoneNumber"),
                CustomerEmail = reader.Get<string>("CustomerEmail"),
                CustomerPassword = reader.Get<string>("CustomerPassword"),
                CustomerPostalCode = reader.Get<string>("CustomerPostalCode"),
                CustomerAddress = reader.Get<string>("CustomerAddress")
            };
        }
    }
}
