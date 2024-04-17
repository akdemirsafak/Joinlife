using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Orders;
using Joinlife.webui.Models.Payment;
using Joinlife.webui.ViewModels.Orders;
using SharedLib.Auth;

namespace Joinlife.webui.Services;

public class OrderService : IOrderService
{
    private readonly IBasketService _basketService;
    private readonly HttpClient _client;
    private readonly IIdentitySharedService _identitySharedService;
    private readonly IPaymentService _paymentService;

    public OrderService(IBasketService basketService,
        HttpClient client,
        IIdentitySharedService identitySharedService,
        IPaymentService paymentService)
    {
        _basketService = basketService;
        _client = client;
        _identitySharedService = identitySharedService;
        _paymentService = paymentService;
    }

    public Task CancelOrder(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderViewModel> CreateAsync(CheckoutInfoInput input)
    {
        var basket = await _basketService.GetAsync();
        var order = new CreateOrderInput
        {
            BuyerId = _identitySharedService.GetUserId
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
            TotalPrice = basket.TotalPrice,
            CardName = input.CardName,
            CardNumber = input.CardNumber,
            ExpirationDate = input.ExpirationDate,
            CVV = input.CVV,
            Order=order
        };
        await _paymentService.ReceivePaymentAsync(paymentInfo); // 500 error

        await _basketService.DeleteAsync();
        //bool isSuccess=await _paymentService.ReceivePaymentAsync(paymentInfo);
        //if (isSuccess)
        //    await _basketService.DeleteAsync();

        return new OrderViewModel(); 
    }

    public Task<List<OrderViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderViewModel> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
