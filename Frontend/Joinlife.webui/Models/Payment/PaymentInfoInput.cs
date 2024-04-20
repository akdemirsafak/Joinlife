using Joinlife.webui.Models.Orders;

namespace Joinlife.webui.Models.Payment;

public class PaymentInfoInput
{
    public string Email { get; set; }
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
    public decimal TotalPrice { get; set; }
    public CreateOrderInput Order { get; set; }
}