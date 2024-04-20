using Joinlife.webui.Core.Services;

namespace Joinlife.webui.Services;

public class NotificationService : INotificationService
{
    private readonly HttpClient _httpClient;

    public NotificationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> SendMailAsync()
    {
        var clientResult =await _httpClient.GetAsync("notification/email");
        return clientResult.IsSuccessStatusCode;
    }

    public async Task<bool> SendSmsAsync()
    {
        var clientResult =await _httpClient.GetAsync("notification/sms");
        return clientResult.IsSuccessStatusCode;
    }
}
