using Microsoft.AspNetCore.Mvc;
using Sales.Application.App_Wrappers.ResponseWrappers;
using Sales.WebApi.MiddlewaresAndHelpers;

namespace Sales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ModelStateErrorConverter]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ResponseResolver<T>(ServiceResponse<T> result)
        {

            if (result.isSuccess)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
