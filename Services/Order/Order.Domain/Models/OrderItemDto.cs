namespace Order.Domain.Models;
public class OrderItemDto
{
    public Guid TicketId { get; set; }
    public string TicketName { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string EventId { get; set; }
    public string EventName { get; set; }
}