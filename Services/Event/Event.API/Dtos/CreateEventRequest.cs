namespace Event.API.Dtos
{
    public record CreateEventRequest(
    string Name,
    Guid VenueId,
    int EventTypeId,
    int StatuId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    decimal Price,
    int SellableTicketAmount,
    string? Description = null);
}