using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.OrganizerDtos;
using Microsoft.AspNetCore.Mvc;

namespace Joinlife.webui.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly IOrganizerService _organizerService;

        public OrganizerController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _organizerService.GetAllAsync());
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            return View(await _organizerService.GetByIdAsync(id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizerInput input)
        {
            await _organizerService.CreateAsync(input);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            GetOrganizerByIdResponse serviceResponse = await _organizerService.GetByIdAsync(id);
            UpdateOrganizerInput updateOrganizerInput = new UpdateOrganizerInput(serviceResponse.Id, serviceResponse.Name, serviceResponse.Description);
            return View(updateOrganizerInput);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrganizerInput input)
        {
            await _organizerService.UpdateAsync(input);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _organizerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}