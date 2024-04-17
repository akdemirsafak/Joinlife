namespace Joinlife.webui.Models.Orders;
public class CreateOrderInput
{
    public CreateOrderInput()
    {
        Items = new List<OrderItemCreateInput>();
    }
    public string BuyerId { get; set; }
    public List<OrderItemCreateInput> Items { get; set; }
}
