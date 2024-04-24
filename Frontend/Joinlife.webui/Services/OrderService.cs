using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Orders;
using Joinlife.webui.Models.Payment;
using Joinlife.webui.ViewModels.Orders;
using SharedLib.Auth;
using SharedLib.Dtos;
using System.Security.Claims;

namespace Joinlife.webui.Services;

public class OrderService : IOrderService
{
    private readonly IBasketService _basketService;
    private readonly HttpClient _client;
    private readonly IIdentitySharedService _identitySharedService;
    private readonly IPaymentService _paymentService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderService(IBasketService basketService,
        HttpClient client,
        IIdentitySharedService identitySharedService,
        IPaymentService paymentService,
        IHttpContextAccessor httpContextAccessor)
    {
        _basketService = basketService;
        _client = client;
        _identitySharedService = identitySharedService;
        _paymentService = paymentService;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<OrderViewModel> CreateAsync(CheckoutInfoInput input)
    {
        var userId= _httpContextAccessor.HttpContext.User.FindFirstValue("sub");
        var userMail = _httpContextAccessor.HttpContext.User.FindFirstValue("email");
        var basket = await _basketService.GetAsync();
        var order = new CreateOrderInput
        {
            BuyerId = userId
        };

        basket.BasketItems.ForEach(x =>
        {
            order.Items.Add(new OrderItemCreateInput
            {
               EventId = x.EventId,
               Price = x.Price,
               Quantity = x.Quantity,
               EventName = x.EventName,
               //PictureUrl = x.PictureUrl,
               TicketId = x.TicketId,
               TicketName = x.TicketName
            });
        });

        var paymentInfo=new PaymentInfoInput
        {
            Email=userMail,
            TotalPrice = basket.TotalPrice,
            CardName = input.CardName,
            CardNumber = input.CardNumber,
            ExpirationDate = input.ExpirationDate,
            CVV = input.CVV,
            Order=order
        };
        bool result = await _paymentService.ReceivePaymentAsync(paymentInfo); // 500 error  BURASI YAPILMAZSA PATLAR RABBITMQ ÇALIŞMAZ.

        await _basketService.DeleteAsync();
        //bool isSuccess=await _paymentService.ReceivePaymentAsync(paymentInfo);
        //if (isSuccess)
        //    await _basketService.DeleteAsync();
        //Ödeme yapılması kısmında order oluşturulacak.


        return new OrderViewModel(); 
    }

    public async Task<List<OrderViewModel>> GetCheckoutHistory()
    {
        var clientResponse = await _client.GetAsync("order");
        
        if (!clientResponse.IsSuccessStatusCode)
        {
            throw new Exception("Sipariş geçmişi getilirken bir problem yaşandı.");
        }
        var content= await clientResponse.Content.ReadFromJsonAsync<AppResponse<List<OrderViewModel>>>();
        return content.Data;
    }

    public async Task<OrderViewModel> GetByIdAsync(Guid id)
    {
        var clientResponse = await _client.GetAsync($"order/{id}");
        if (!clientResponse.IsSuccessStatusCode)
            throw new Exception("Sipariş görüntülenemiyor.");
        var content = await clientResponse.Content.ReadFromJsonAsync<AppResponse<OrderViewModel>>();
        return content.Data;
    }
}
