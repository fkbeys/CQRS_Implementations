using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Persistence.Meds.Commands.ProductCommands;
using Sales.Persistence.Meds.Queries.ProductQueries;

namespace Sales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
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
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var request = new GetAllProductQuery();
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }






    }
}
