using Payment.API.Models;

namespace Payment.API.Services;

public interface IPaymentService
{
    Task<bool> ReceivePaymentAsync(PaymentInfoDto paymentInfo);
}
