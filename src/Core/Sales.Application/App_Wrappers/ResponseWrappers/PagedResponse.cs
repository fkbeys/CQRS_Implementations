namespace Sales.Application.App_Wrappers.ResponseWrappers
{
    public class PagedResponse<T> : ServiceResponse<T>
    {
        public int pageNumber { get; set; } = 0;
        public int pageSize { get; set; } = 10;
        public int totalCount { get; set; } = 10;

        public PagedResponse(T obj, int pageNumber, int pageSize, int totalCount) : base(obj)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.totalCount = totalCount;
        }

        public PagedResponse(T obj) : base(obj)
        {

        }

    }
}
