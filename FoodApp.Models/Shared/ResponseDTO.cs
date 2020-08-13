namespace FoodApp.DataModels.Shared
{
    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public bool SessionInit { get; set; }
        public T Result { get; set; }
    }
}
