using AutoMapper;
using MediatR;
using Sales.Application.App_Dto;
using Sales.Application.App_Exceptions;
using Sales.Application.App_Wrappers.Responses;
using Sales.Persistence.Meds.Queries;
using Sales.Persistence.Persist_UnitOfWork;

namespace Sales.Persistence.Meds.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ServiceResponse<List<ProductDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<ServiceResponse<List<ProductDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            ServiceResponse<List<ProductDto>> result = new ServiceResponse<List<ProductDto>>(null);
            try
            {
                var data = await unitOfWork.productRepository.GetAllAsync();

                result.Value = mapper.Map<List<ProductDto>>(data);

                result.isSuccess = true;
                result.message = "Product data listed successfully.";
            }
            catch (Exception ex)
            {
                result = GenericException.BuildError<List<ProductDto>>(ex);
            }
            return result;
        }
    }
}
