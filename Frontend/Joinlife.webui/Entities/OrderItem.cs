namespace Joinlife.webui.Entities
{
    public sealed class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid EventId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
