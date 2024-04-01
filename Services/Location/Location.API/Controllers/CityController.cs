using Microsoft.AspNetCore.Mvc;

namespace Location.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }
    }
}
