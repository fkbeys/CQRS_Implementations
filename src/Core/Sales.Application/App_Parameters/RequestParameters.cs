namespace Sales.Application.App_Parameters
{
    public class RequestParameters
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }

        public RequestParameters(int pageSize, int pageNumber)
        {
            this.pageSize = pageSize;
            this.pageNumber = pageNumber;
        }
    }
}
