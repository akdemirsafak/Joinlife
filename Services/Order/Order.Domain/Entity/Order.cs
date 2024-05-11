namespace Order.Domain.Entity;

public sealed class Order
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public DateTime CreatedAt { get; set; }= DateTime.Now;
    public List<OrderItem> OrderItems { get; set; }
    public decimal TotalPrice => OrderItems.Sum(x => x.Price * x.Quantity);
    public StatusEnum Statu { get; set; }= StatusEnum.Active;

    public Order()
    {
        Id = Guid.NewGuid();
    }
}
public enum StatusEnum
{
    Active=1,
    Cancelled
}
