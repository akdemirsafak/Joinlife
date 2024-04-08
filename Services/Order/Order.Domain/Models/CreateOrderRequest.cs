namespace Order.Domain.Models
{
    public record CreateOrderRequest(List<OrderItemDto> OrderItems, Guid BuyerId);
}