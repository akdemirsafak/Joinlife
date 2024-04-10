using Joinlife.webui.Common;
using Joinlife.webui.Core.Services;
using Joinlife.webui.Mappers;
using Joinlife.webui.Models.EventDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Joinlife.webui.Controllers;

public class EventController : Controller
{
    private readonly IEventService _eventService;
    private readonly IVenueService _venueService;
    CommonMapper _mapper =new CommonMapper();


    public EventController(IEventService eventService, IVenueService venueService)
    {
        _eventService = eventService;
        _venueService = venueService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Venues = await _venueService.GetAllAsync();
        return View(await _eventService.GetAllAsync());
    }

    public async Task<IActionResult> Detail(Guid id)
    {
        return View(await _eventService.GetAsync(id));
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.Venues = new SelectList(await _venueService.GetAllAsync(), "Id", "Name");

        var eventTypes = Enum.GetValues(typeof(EventTypeEnum))
            .Cast<EventTypeEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()// Requires System.ComponentModel.DataAnnotations namespace
            })
            .ToList();
        var eventStatus = Enum.GetValues(typeof(EventStatusEnum))
            .Cast<EventStatusEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()// Requires System.ComponentModel.DataAnnotations namespace
            })
            .ToList();
        ViewBag.EventTypes = eventTypes;
        ViewBag.EventStatus = eventStatus;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateEventInput input)
    {
        await _eventService.CreateAsync(input);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(Guid id)
    {
        await _eventService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var organization = await _eventService.GetAsync(id);

        var organizationUpdateInputModel= _mapper.GetEventByIdResponseToUpdateEventInput(organization);
        ViewBag.Venues = new SelectList(await _venueService.GetAllAsync(), "Id", "Name");
        // ! ViewBag'ler yerine Tempdata'lar kullanalım ki hata çıkması durumunda sayfadaki selectlist'ler gelsin.
        var eventTypes = Enum.GetValues(typeof(EventTypeEnum))
            .Cast<EventTypeEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString(), // Requires System.ComponentModel.DataAnnotations namespace
                Selected = (int)e == organization.EventTypeId
            })
            .ToList();
        var eventStatus = Enum.GetValues(typeof(EventStatusEnum))
            .Cast<EventStatusEnum>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()// Requires System.ComponentModel.DataAnnotations namespace
            })
            .ToList();
        ViewBag.EventTypes = eventTypes;
        ViewBag.EventStatus = eventStatus;
        return View(organizationUpdateInputModel);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateEventInput input)
    {
        await _eventService.UpdateAsync(input);
        return RedirectToAction(nameof(Index));
    }
}