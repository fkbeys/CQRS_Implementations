using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Persistence.Meds.Commands.ProductCommands;
using Sales.Persistence.Meds.Queries.ProductQueries;

namespace Sales.WebApi.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new GetProductQueryById() { id = id };
            var result = await mediator.Send(request);
            return ResponseResolver(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllData()
        { 
            var request = new GetAllProductQuery();
            var result = await mediator.Send(request);
            return ResponseResolver(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            var result = await mediator.Send(command);
            return ResponseResolver(result);             
        }
    }
}
