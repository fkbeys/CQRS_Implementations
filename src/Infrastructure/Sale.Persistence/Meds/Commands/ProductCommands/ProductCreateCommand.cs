using MediatR;
using Sales.Application.App_Wrappers.ResponseWrappers;

namespace Sales.Persistence.Meds.Commands.ProductCommands
{
    public class ProductCreateCommand : IRequest<ServiceResponse<Guid>>
    {
        public string name { get; set; }
        public int taxRate { get; set; }
    }
}
