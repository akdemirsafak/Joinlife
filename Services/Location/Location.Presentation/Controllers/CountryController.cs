using Location.Application.Features.Country.Commands;
using Location.Application.Features.Country.Queries;
using Location.Domain.Models.Request.Countries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLib.BaseController;

namespace Location.API.Controllers;

public class CountryController : CustomBaseController
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _mediator.Send(new GetCountries.Query()));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateActionResult(await _mediator.Send(new GetCountryById.Query(id)));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCountryRequest request)
    {
        return CreateActionResult(await _mediator.Send(new CreateCountry.Command(request)));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCountryRequest request, Guid id)
    {
        return CreateActionResult(await _mediator.Send(new UpdateCountry.Command(request, id)));
    }
}
