
namespace FoodApp.DataModels.Shared
{
    public class PagingDTO
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public bool All { get; set; }
    }
}
