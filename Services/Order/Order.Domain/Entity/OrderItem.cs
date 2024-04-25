namespace Order.Domain.Entity;

public sealed class OrderItem
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid EventId { get; set; }
    public int Quantity { get; set; }
    public string TicketName { get; set; }
    public string EventName { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }

    public OrderItem()
    {
        Id = Guid.NewGuid();
    }
}
