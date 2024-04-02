using Microsoft.AspNetCore.Mvc;
using SharedLib.Dtos;
namespace SharedLib.BaseController
{
    [Route("[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(AppResponse<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,

            };
        }
    }
}
