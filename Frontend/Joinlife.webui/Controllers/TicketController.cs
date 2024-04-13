using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Joinlife.webui.Controllers;

public class TicketController : Controller
{
    private readonly IEventService _eventService;
    private readonly ITicketService _ticketService;

    public TicketController(IEventService eventService, ITicketService ticketService)
    {
        _eventService = eventService;
        _ticketService = ticketService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Create(Guid id)
    {
        ViewBag.Event= await _eventService.GetAsync(id);
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateTicketInput createTicketInput)
    {
        var response= await _ticketService.CreateAsync(createTicketInput);
        if (response is null)
            return View(createTicketInput);
        return RedirectToAction("Detail","Event",new { id = createTicketInput.EventId });

    }
}
