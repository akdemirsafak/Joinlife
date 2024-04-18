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

    [HttpPost]
    public async Task<IActionResult> ReceivePayment(PaymentInfoDto paymentInfo)
    {

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


        //var result = await _paymentService.ReceivePaymentAsync(paymentInfo);
        //if (result)
        //{
        //    return Created();
        //}
        //return BadRequest();

    }
}
