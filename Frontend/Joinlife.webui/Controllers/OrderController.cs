using Joinlife.webui.Core.Services;
using Joinlife.webui.ViewModels.Baskets;
using Joinlife.webui.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Joinlife.webui.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IBasketService _basketService;

    public OrderController(IOrderService orderService,
        IBasketService basketService)
    {
        _orderService = orderService;
        _basketService = basketService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _orderService.GetAllAsync());
    }

    public async Task<IActionResult> Checkout()
    {
        BasketViewModel basket = await _basketService.GetAsync();
        ViewBag.Basket = basket;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Checkout(CheckoutInfoInput checkoutInfoInput)
    {
        var orderViewModel= await _orderService.CreateAsync(checkoutInfoInput);
        return RedirectToAction("Index","Home");
    }

    public async Task<IActionResult> OrderDetail(Guid id)
    {
        return View();
    }
}
