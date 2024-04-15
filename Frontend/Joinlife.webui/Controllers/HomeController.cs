using Joinlife.webui.Exceptions;
using Joinlife.webui.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Joinlife.webui.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var errorFeature= HttpContext.Features.Get<IExceptionHandlerFeature>();
        if (errorFeature is not null && errorFeature.Error is UnAuthorizeException) //Bizim fırlattığımız hata
        {
            return RedirectToAction(nameof(AuthController.LogOut),"Auth");
        }
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
