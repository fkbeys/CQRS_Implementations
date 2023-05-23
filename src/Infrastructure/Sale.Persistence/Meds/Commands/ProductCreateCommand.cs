using MediatR;
using Sales.Application.App_Wrappers.Responses;

namespace Sales.Persistence.Meds.Commands
{
    public class ProductCreateCommand : IRequest<ServiceResponse<Guid>>
    {
        public string name { get; set; }
        public int taxRate { get; set; }
    }
}
