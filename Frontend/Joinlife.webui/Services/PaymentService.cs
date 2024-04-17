using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Payment;

namespace Joinlife.webui.Services;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;

    public PaymentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ReceivePaymentAsync(PaymentInfoInput input)
    {
        var clientResponse= await _httpClient.PostAsJsonAsync<PaymentInfoInput>("payment", input);
        return clientResponse.IsSuccessStatusCode;
    }
}
