namespace Notification.API.Services;

public interface INotificationService
{
    Task<bool> SendMailAsync();
    Task<bool> SendSmsAsync();
}
