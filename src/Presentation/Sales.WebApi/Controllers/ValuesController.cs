using Microsoft.AspNetCore.Mvc;
using Sales.Persistence.Persist_UnitOfWork;

namespace Sales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var data = await unitOfWork.productRepository.GetAll();

            return Ok(data);
        }



        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var data = await unitOfWork.productRepository.GetAll();

            return Ok(data);
        }



    }
}
