using Microsoft.AspNetCore.Mvc;
namespace SharedLib.BaseController
{
    public class CustomBaseController
    {
        [Route("[controller]")]
        [ApiController]
        public class CustomBaseController : ControllerBase
        {
            [NonAction]
            public IActionResult CreateActionResult<T>(Response<T> response)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode,

                };
            }
        }
    }
}
