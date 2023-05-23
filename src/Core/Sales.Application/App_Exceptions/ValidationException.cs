namespace Sales.Application.App_Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Validation Error Occured")
        {

        }


        public ValidationException(string message) : base(message)
        {

        }

        public ValidationException(Exception ex) : this(ex.Message)
        {

        }

    }
}
