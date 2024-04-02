using Location.Application.Features.Venue.Commands;
using Location.Application.Features.Venue.Queries;
using Location.Domain.Models.Request.Venue;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLib.BaseController;


namespace Location.API.Controllers;
public class VenueController : CustomBaseController
{
    private readonly IMediator _mediator;

    public VenueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _mediator.Send(new GetVenues.Query()));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateActionResult(await _mediator.Send(new GetVenueById.Query(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVenueRequest request)
    {
        return CreateActionResult(await _mediator.Send(new CreateVenue.Command(request)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateVenueRequest request, Guid id)
    {

        return CreateActionResult(await _mediator.Send(new UpdateVenue.Command(request, id)));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return CreateActionResult(await _mediator.Send(new DeleteVenue.Command(id)));
    }
}