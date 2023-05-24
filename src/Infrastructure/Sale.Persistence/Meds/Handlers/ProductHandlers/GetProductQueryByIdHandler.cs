using AutoMapper;
using MediatR;
using Sales.Application.App_Dto;
using Sales.Application.App_Exceptions;
using Sales.Application.App_Wrappers.ResponseWrappers;
using Sales.Persistence.Meds.Queries.ProductQueries;
using Sales.Persistence.Persist_UnitOfWork;

namespace Sales.Persistence.Meds.Handlers.ProductHandlers
{
    public class GetProductQueryByIdHandler : IRequestHandler<GetProductQueryById, ServiceResponse<ProductDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProductQueryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<ProductDto>> Handle(GetProductQueryById request, CancellationToken cancellationToken)
        {
            ServiceResponse<ProductDto> result = new ServiceResponse<ProductDto>(null);
            try
            {
                var data = await unitOfWork.productRepository.GetByIdAsync(request.id);
                result.Value = mapper.Map<ProductDto>(data);

                result.isSuccess = true;
                result.message = "Product record found successfully.";
            }
            catch (Exception ex)
            {
                result = GenericException.BuildError<ProductDto>(ex);
            }
            return result;
        }
    }
}
