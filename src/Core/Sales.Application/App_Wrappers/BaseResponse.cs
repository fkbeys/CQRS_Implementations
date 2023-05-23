namespace Sales.Application.App_Wrappers
{
    public class BaseResponse
    {
        public Guid id { get; set; }
        public bool isSuccess { get; set; }
        public string? message { get; set; }

    }
}
