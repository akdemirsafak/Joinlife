using Joinlife.webui.Core.Services;
using Joinlife.webui.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;

namespace Joinlife.webui.Controllers;

public class BasketController : Controller
{
    private readonly ITicketService _ticketService;
    private readonly IBasketService _basketService;

    public BasketController(ITicketService ticketService, 
        IBasketService basketService)
    {
        _ticketService = ticketService;
        _basketService = basketService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _basketService.GetAsync());
    }

    public async Task<IActionResult> AddBasketItem(Guid ticketId)
    {
        var ticket = await _ticketService.GetById(ticketId); 
        var basketItem = new BasketItemViewModel 
        { 
            TicketId=ticket.Id,
            TicketName=ticket.Name,
            EventId=ticket.EventId,
            EventName=ticket.EventName,
            EventImageUrl=ticket.EventImageUrl,
            Price=ticket.Price
        };
        await _basketService.AddBasketItemAsync(basketItem);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> RemoveBasketItem(Guid basketItemId)
    {
        var result= await _basketService.RemoveBasketItemAsync(basketItemId);
        return RedirectToAction(nameof(Index));
    }

}
