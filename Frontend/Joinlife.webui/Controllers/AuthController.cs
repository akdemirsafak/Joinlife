using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Joinlife.webui.Controllers;


public class AuthController : Controller
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public IActionResult Signin()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Signin(SigninInputModel model)
    {
       var result= await _identityService.SignInAsync(model);
        if (result.StatusCode==200)
        {
            return RedirectToAction("Index", nameof(HomeController));
        }
        return View(model);
    }
    public IActionResult Signup() 
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Signup(SignupInputModel model)
    {
        var result=await _identityService.SignUpAsync(model);
        if (result.StatusCode == 201)
            return RedirectToAction("Index", nameof(HomeController));
        return View(model);
    }
}
