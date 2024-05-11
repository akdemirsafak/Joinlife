using MailKit.Net.Smtp;
using MassTransit;
using Microsoft.Extensions.Options;
using MimeKit;
using Notification.API.Settings;
using SharedLib.Messages;

namespace Notification.API.Consumers;

public class CreateOrderNotificationMessageCommandConsumer : IConsumer<CreateOrderNotificationMessageCommand>
{
    private readonly EmailSettings _emailSettings;

    public CreateOrderNotificationMessageCommandConsumer(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task Consume(ConsumeContext<CreateOrderNotificationMessageCommand> context)
    {
        var message= new MimeMessage();
        message.From.Add(new MailboxAddress("Joinlife",_emailSettings.Email));
        message.To.Add(new MailboxAddress("Alıcı",context.Message.Email));
        message.Subject = "Siparişiniz Oluşturuldu.";
        message.Body = new TextPart("HTML")
        {
            Text = @"
                    <h3>Joinlife</h3>
                    <p>Siparişiniz başarıyla oluşturuldu.</p>
                    <p>Sipariş Detayları:</p>
                    <table>
                        <thead>
                            <tr>
                                <th>Etkinliğin adı</th>
                                <th>Bilet türü</th>
                                <th>Fiyat</th>
                                <th>Adet</th>
                            </tr>
                        </thead>
                        <tbody>
                            " + string.Join("", context.Message.Items.Select(x => $@"
                            <tr>
                                <td>{x.EventName}</td>
                                <td>{x.TicketName}</td>
                                <td>{x.Price}</td>
                                <td>{x.Quantity}</td>
                            </tr>")) + @"
                        </tbody>
                    </table>
                <p>Toplam Fiyat: " + context.Message.Items.Sum(x => x.Price * x.Quantity) + @"</p>
            "
        };
        using(var client=new SmtpClient())
        {
            client.Connect(_emailSettings.Host,587,false);
            client.Authenticate(_emailSettings.Email,_emailSettings.Password);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
