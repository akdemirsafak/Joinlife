using Event.API.Core;
using Event.API.Dtos.Events;
using Microsoft.AspNetCore.Mvc;
using SharedLib.BaseController;

namespace Event.API.Controllers;

public class EventController : CustomBaseController
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _eventService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateActionResult(await _eventService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventRequest createEventRequest)
    {
        return CreateActionResult(await _eventService.CreateAsync(createEventRequest));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateEventRequest updateEventRequest, Guid id)
    {
        return CreateActionResult(await _eventService.UpdateAsync(updateEventRequest, id));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return CreateActionResult(await _eventService.DeleteAsync(id));
    }
}
