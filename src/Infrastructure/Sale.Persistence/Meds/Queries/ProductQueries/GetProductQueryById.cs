using MediatR;
using Sales.Application.App_Dto;
using Sales.Application.App_Wrappers.ResponseWrappers;

namespace Sales.Persistence.Meds.Queries.ProductQueries
{
    public class GetProductQueryById : IRequest<ServiceResponse<ProductDto>>
    {
        public Guid id { get; set; }
    }
}
