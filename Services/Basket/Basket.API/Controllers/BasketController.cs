using Basket.API.Dtos;
using Basket.API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLib.Auth;
using SharedLib.BaseController;

namespace Basket.API.Controllers;

public class BasketController : CustomBaseController
{
   private readonly IBasketService _basketService;
   private readonly IIdentitySharedService _identitySharedService;

    public BasketController(IBasketService basketService,
        IIdentitySharedService identitySharedService)
    {
        _basketService = basketService;
        _identitySharedService = identitySharedService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBasket()
    {
        var userId = _identitySharedService.GetUserId;
        return CreateActionResult(await _basketService.GetBasket(userId));
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
    {
        basketDto.UserId = _identitySharedService.GetUserId;
        return CreateActionResult(await _basketService.SaveOrUpdate(basketDto));
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        return CreateActionResult(await _basketService.Delete(_identitySharedService.GetUserId));
    }
}
