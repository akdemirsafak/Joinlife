using Event.API.Core;
using Event.API.Dtos.Tickets;
using Microsoft.AspNetCore.Mvc;
using SharedLib.BaseController;

namespace Event.API.Controllers;

public class TicketController : CustomBaseController
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateActionResult(await _ticketService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateActionResult(await _ticketService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateTicketRequest request)
    {
        return CreateActionResult(await _ticketService.CreateAsync(request));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateTicketRequest request, Guid id)
    {
        return CreateActionResult(await _ticketService.UpdateAsync(request, id));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return CreateActionResult(await _ticketService.DeleteAsync(id));
    }
}
