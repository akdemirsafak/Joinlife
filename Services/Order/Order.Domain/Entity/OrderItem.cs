namespace Order.Domain.Entity;

public sealed class OrderItem
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public int Amount { get; set; }
    public string TicketName { get; set; }
    public decimal Price { get; set; }

    public OrderItem()
    {
        Id = Guid.NewGuid();
    }
}
