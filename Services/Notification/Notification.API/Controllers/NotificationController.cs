using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using Notification.API.Settings;
using SharedLib.Auth;
using SharedLib.BaseController;

namespace Notification.API.Controllers;


public class NotificationController : CustomBaseController
{
    private readonly EmailSettings _emailSettings;
    private readonly IIdentitySharedService _identitySharedService;
    public NotificationController(IOptions<EmailSettings> emailSettings, 
        IIdentitySharedService identitySharedService)
    {
        _emailSettings = emailSettings.Value;
        _identitySharedService = identitySharedService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Notification Service is working");
    }
    [HttpPost]
    public async Task<IActionResult> SendMail(string email)
    {
        var message= new MimeMessage();
        message.From.Add(new MailboxAddress("Joinlife", _emailSettings.Email));
        message.To.Add(new MailboxAddress("girilen", email));
        message.Subject = "Siparişiniz Oluşturuldu.";
        message.Body = new TextPart("HTML")
        {
            Text = @"
                    <h3>Joinlife</h3>
                    <p>Siparişiniz başarıyla oluşturuldu.</p>
                    <p>Sipariş Detayları:</p>
             "
        };

        using (var client = new SmtpClient())
        {
            client.Connect(_emailSettings.Host, 587, false);
            client.Authenticate(_emailSettings.Email, _emailSettings.Password);
            client.Send(message);
            client.Disconnect(true);
        }

        return Ok("Mail Sent");
    }
}
