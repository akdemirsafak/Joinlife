namespace Joinlife.webui.Models.EventDtos
{
    public sealed class GetEventResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string EventType { get; set; }
        public int EventTypeId { get; set; }
        public Guid VenueId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Duration => (EndDateTime - StartDateTime).ToString(@"hh\:mm");
    }
}