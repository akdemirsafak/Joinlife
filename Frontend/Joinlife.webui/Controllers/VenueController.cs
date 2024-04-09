using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.VenueDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Joinlife.webui.Controllers;

public class VenueController : Controller
{
    private readonly IVenueService _venueService;
    private readonly ICityService _cityService;

    public VenueController(IVenueService venueService, ICityService cityService)
    {
        _venueService = venueService;
        _cityService = cityService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _venueService.GetAllAsync());
    }

    public async Task<IActionResult> Detail(Guid id)
    {
        return View(await _venueService.GetByIdAsync(id));
    }


    public async Task<IActionResult> Create()
    {
        ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateVenueInput input)
    {
        await _venueService.CreateAsync(input);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(Guid id)
    {
        ViewBag.Cities = new SelectList(await _cityService.GetAllAsync(), "Id", "Name");
        var venue = await _venueService.GetByIdAsync(id);
        var updateInputModel = new UpdateVenueInput(venue.Id, venue.Name, venue.Line, venue.CityId);
        return View(updateInputModel);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateVenueInput input)
    {
        await _venueService.UpdateAsync(input);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _venueService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}