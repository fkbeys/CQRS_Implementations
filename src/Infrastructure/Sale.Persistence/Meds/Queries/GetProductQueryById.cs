using MediatR;
using Sales.Application.App_Dto;
using Sales.Application.App_Wrappers.Responses;

namespace Sales.Persistence.Meds.Queries
{
    public class GetProductQueryById : IRequest<ServiceResponse<ProductDto>>
    {
        public Guid id { get; set; }
    }
}
