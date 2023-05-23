using Sales.Application.App_Wrappers.Responses;

namespace Sales.Application.App_Exceptions
{
    public static class GenericException
    {
        public static ServiceResponse<T> BuildError<T>(Exception ex)
        {
            var result = new ServiceResponse<T>(default);
            result.isSuccess = false;
            result.message = ex.Message ?? "" + " " + ex.InnerException ?? "";
            return result;
        }


    }
}
