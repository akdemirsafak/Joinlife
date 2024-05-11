namespace Joinlife.webui.Core.Services;

public interface INotificationService
{
    Task<bool> SendMailAsync();
    Task<bool> SendSmsAsync();
}
