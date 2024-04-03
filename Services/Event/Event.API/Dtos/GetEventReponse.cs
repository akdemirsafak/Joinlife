namespace Event.API.Dtos
{
    public sealed class GetEventReponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string EventType { get; set; }
        public int EventTypeId { get; set; }
        public Guid VenueId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int SellableTicketAmount { get; set; }
        public int SelledTicketAmount { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Statu { get; set; }
        public int StatuId { get; set; }
    }
}