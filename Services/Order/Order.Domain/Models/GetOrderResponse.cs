namespace Order.Domain.Models;
public class GetOrderResponse
{

    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public decimal TotalPrice => OrderItems.Sum(x => x.Price * x.Quantity);
    public string Statu { get; set; }
    public int StatuId { get; set; }
}