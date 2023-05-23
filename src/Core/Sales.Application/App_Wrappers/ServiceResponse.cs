namespace Sales.Application.App_Wrappers
{
    public class ServiceResponse<T>
    {
        public T? Value { get; set; }

        public ServiceResponse(T? value)
        {
            Value = value;
        }
    }
}
