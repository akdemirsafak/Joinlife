using Location.Application.Features.Country.Commands;
using Location.Application.Features.Country.Queries;
using Location.Domain.Models.Request.Countries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Location.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetCountries.Query()));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _mediator.Send(new GetCountryById.Query(id)));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCountryRequest request)
    {
        return Ok(await _mediator.Send(new CreateCountry.Command(request)));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCountryRequest request, Guid id)
    {
        return Ok(await _mediator.Send(new UpdateCountry.Command(request, id)));
    }
}
