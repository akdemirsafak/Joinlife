using Payment.API.Models;

namespace Payment.API.Services;

public class PaymentService : IPaymentService
{
    public async Task<bool> ReceivePaymentAsync(PaymentInfoDto paymentInfo)
    {
        return true;
    }
}
