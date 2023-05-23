namespace Sales.Application.App_Wrappers.Responses
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T? Value { get; set; }

        public ServiceResponse(T? value)
        {
            Value = value;
        }
    }
}
