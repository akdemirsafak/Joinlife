using Location.Application.Features.City.Commands;
using Location.Application.Features.City.Queries;
using Location.Domain.Models.Request.Cities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Location.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCities.Query()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetCityById.Query(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityRequest request)
        {
            return Ok(await _mediator.Send(new CreateCity.Command(request)));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateCityRequest request, Guid id)
        {
            return Ok(await _mediator.Send(new UpdateCity.Command(request, id)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCity.Command(id));
            return Ok();
        }
    }
}
