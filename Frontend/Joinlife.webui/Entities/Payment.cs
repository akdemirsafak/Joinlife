namespace Joinlife.webui.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public DateTime PayDateTime { get; set; }
        public decimal Total { get; set; }
    }
}
