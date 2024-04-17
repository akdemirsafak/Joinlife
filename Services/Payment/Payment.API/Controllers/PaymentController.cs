using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;
using Payment.API.Services;
using SharedLib.BaseController;

namespace Payment.API.Controllers;


public class PaymentController : CustomBaseController
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> ReceivePayment(PaymentInfoDto paymentInfo)
    {
        var result = await _paymentService.ReceivePaymentAsync(paymentInfo);
        //if (result)
        //{
        //    return Created();
        //}
        //return BadRequest();
        return Ok(paymentInfo);
    }
}
