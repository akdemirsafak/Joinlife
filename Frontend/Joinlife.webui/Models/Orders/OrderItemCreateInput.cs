namespace Joinlife.webui.Models.Orders;
public class OrderItemCreateInput
{
    public Guid TicketId { get; set; }
    public string TicketName { get; set; }
    public string EventName { get; set; }
    public Guid EventId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}