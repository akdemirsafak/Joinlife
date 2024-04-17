namespace Payment.API.Models;

public class PaymentInfoDto
{
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
    public decimal TotalPrice { get; set; }
    public CreateOrderInput Order { get; set; }
}
public class CreateOrderInput
{
    public Guid BuyerId { get; set; }
    public List<OrderItemCreateInput> Items { get; set; } = new List<OrderItemCreateInput>();
}
public class OrderItemCreateInput
{
    public Guid EventId { get; set; }
    public string EventName { get; set; }
    public Guid TicketId { get; set; }
    public string TicketName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
