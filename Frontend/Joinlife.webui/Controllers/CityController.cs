using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.City;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Joinlife.webui.Controllers;

public class CityController : Controller
{
    private readonly ICityService _cityService;
    private readonly ICountryService _countryService;

    public CityController(ICityService cityService,
        ICountryService countryService)
    {
        _cityService = cityService;
        _countryService = countryService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _cityService.GetAllAsync());
    }

    public async Task<IActionResult> Detail(Guid id)
    {
        return View(await _cityService.GetAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCityInput input)
    {
        await _cityService.CreateAsync(input);
        return Redirect(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        ViewBag.Countries = new SelectList(await _countryService.GetAllAsync(), "Id", "Name");
        var cityResponse = await _cityService.GetAsync(id);

        var updateCityResponse = new UpdateCityInput
        {
            Id = cityResponse.Id,
            Name = cityResponse.Name,
            CountryId = cityResponse.Country.Id,
            ImageUrl = cityResponse.ImageUrl
        };
        return View(updateCityResponse);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateCityInput input)
    {
        await _cityService.UpdateAsync(input);
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _cityService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}