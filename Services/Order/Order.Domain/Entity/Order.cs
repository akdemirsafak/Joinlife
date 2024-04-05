namespace Order.Domain.Entity;

public sealed class Order
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public DateTime CreatedAt { get; set; }= DateTime.Now;
    public List<OrderItem> OrderItems { get; set; }
    public decimal TotalPrice { get; set; }

    public Order()
    {
        Id = Guid.NewGuid();
    }
}
