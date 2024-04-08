namespace Event.API.Dtos.Events
{
    public record CreateEventRequest(
    string Name,
    Guid VenueId,
    int EventTypeId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    int StatuId = 1,
    string? Description = null);
}