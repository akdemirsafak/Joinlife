namespace Basket.API.Dtos;

public class BasketItemDto
{
    public int Quantity { get; set; }
    public string TicketId { get; set; }
    public string TicketName { get; set; }
    public string EventId { get; set; }
    public string EventName { get; set; }
    public decimal Price { get; set; }
}
