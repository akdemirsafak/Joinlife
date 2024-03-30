using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace Joinlife.webui.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _countryService.GetAllAsync());
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            return View(await _countryService.GetAsync(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryInput input)
        {
            await _countryService.CreateAsync(input);
            return Redirect(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var countryResponse = await _countryService.GetAsync(id);
            var updateCountryInputModel = new UpdateCountryInput
            {
                Name = countryResponse.Name,
                Id = countryResponse.Id
            };
            return View(updateCountryInputModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountryInput input)
        {
            await _countryService.UpdateAsync(input);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _countryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}