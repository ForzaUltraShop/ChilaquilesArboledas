namespace FoodApp.DataModels.Shared
{
    public class RequestDTO<T> where T : class
    {
        public OperationType OperationType { get; set; }

        public PagingDTO Paging { get; set; }

        public string WordFilter { get; set; }

        public T Item { get; set; }

        public  string ServerPath { get; set; }
    }
}
