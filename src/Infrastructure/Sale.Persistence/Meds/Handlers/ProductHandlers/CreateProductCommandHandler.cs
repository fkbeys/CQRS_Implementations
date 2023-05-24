using MediatR;
using Sales.Application.App_Exceptions;
using Sales.Application.App_Wrappers.ResponseWrappers;
using Sales.Domain.Domain_Entities;
using Sales.Persistence.Meds.Commands.ProductCommands;
using Sales.Persistence.Persist_UnitOfWork;

namespace Sales.Persistence.Meds.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<ProductCreateCommand, ServiceResponse<Guid>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<Guid>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            ServiceResponse<Guid> result = new ServiceResponse<Guid>(Guid.Empty);

            try
            {

                var isExist = await unitOfWork.productRepository.isExist(x => x.name == request.name);
                if (isExist)
                    throw new Exception("Record already exist!") { };

                var obj = new Product
                {
                    id = Guid.NewGuid(),
                    name = request.name,
                    createDate = DateTime.Now,
                    maxLevel = 0,
                    minLevel = 0,
                    origin = "",
                    taxRate = request.taxRate,
                };

                await unitOfWork.productRepository.AddAsync(obj);
                await unitOfWork.SaveChangesAsync();
                result.Value = obj.id;
                result.isSuccess = true;
                result.message = "Product created successfully.";
            }
            catch (Exception ex)
            {
                result = GenericException.BuildError<Guid>(ex);
            }

            return result;
        }
    }
}
