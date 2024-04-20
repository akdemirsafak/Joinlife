using Mapster;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;
using SharedLib.BaseController;
using SharedLib.Messages;
namespace Payment.API.Controllers;


public class PaymentController : CustomBaseController
{
    private readonly ISendEndpointProvider _sendEndpointProvider;
    
    public PaymentController(ISendEndpointProvider sendEndpointProvider)
    {
        _sendEndpointProvider = sendEndpointProvider;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Payment Service");
    }

    [HttpPost]
    public async Task<IActionResult> ReceivePayment(PaymentInfoDto paymentInfo)
    {
        //Ödemeyi tamamla 

        var sendNotificationEndpoint= _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-notification-service"));
        var createOrderNotificationCommand = new CreateOrderNotificationMessageCommand
        {
            Items = paymentInfo.Order.Items.Adapt<List<OrderItemDto>>(),
            Email=paymentInfo.Email
        };

        await _sendEndpointProvider.Send<CreateOrderNotificationMessageCommand>(createOrderNotificationCommand);



        var sendEndpoint = _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));
        var createOrderCommand = new CreateOrderMessageCommand
        {
            BuyerId = paymentInfo.Order.BuyerId,
            Items = paymentInfo.Order.Items.Select(x => new OrderItemCreateDto
            {
                EventId = x.EventId,
                EventName = x.EventName,
                Price = x.Price,
                Quantity = x.Quantity,
                TicketId = x.TicketId,
                TicketName = x.TicketName
            }).ToList()
        };

        await _sendEndpointProvider.Send<CreateOrderMessageCommand>(createOrderCommand);

   
        return Ok(paymentInfo);
    }
}
