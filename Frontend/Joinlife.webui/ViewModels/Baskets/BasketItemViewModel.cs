namespace Joinlife.webui.ViewModels.Baskets;

public class BasketItemViewModel
{
    public int Quantity { get; set; } = 1;
    public Guid TicketId { get; set; }
    public string TicketName { get; set; }
    public Guid EventId { get; set; }
    public string EventName { get; set; }
    public string EventImageUrl { get; set; }
    public decimal Price { get; set; }
    public decimal CurrentPrice { get => Price * Quantity; }
}
