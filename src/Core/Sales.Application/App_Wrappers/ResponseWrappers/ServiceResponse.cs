namespace Sales.Application.App_Wrappers.ResponseWrappers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T? data { get; set; }

        public ServiceResponse(T? data)
        {
            this.data = data;
        }
    }
}
