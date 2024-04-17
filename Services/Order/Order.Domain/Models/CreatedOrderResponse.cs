namespace Order.Domain.Models;

public class CreatedOrderResponse
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public decimal TotalPrice => OrderItems.Sum(x => x.Price * x.Amount);
}