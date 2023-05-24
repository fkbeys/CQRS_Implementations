using MediatR;
using Sales.Application.App_Dto;
using Sales.Application.App_Wrappers.ResponseWrappers;

namespace Sales.Persistence.Meds.Queries.ProductQueries
{
    public class GetAllProductQuery : IRequest<ServiceResponse<List<ProductDto>>>
    {
    }
}
