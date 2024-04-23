using Event.API.Dtos.Events;

namespace Event.API.Dtos.Tickets;

public class GetTicketResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid EventId { get; set; }
    public string EventName { get; set; }
    public string EventImageUrl { get; set; }
    //public virtual GetEventReponse Event { get; set; }
}