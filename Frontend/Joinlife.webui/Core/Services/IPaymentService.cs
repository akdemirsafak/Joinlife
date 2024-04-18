using Joinlife.webui.Models.Payment;

namespace Joinlife.webui.Core.Services;

public interface IPaymentService
{
    Task<bool> ReceivePaymentAsync(PaymentInfoInput input);
}
