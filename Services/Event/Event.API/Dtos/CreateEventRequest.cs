namespace Event.API.Dtos
{
    public record CreateEventRequest(
    string Name,
    Guid VenueId,
    int EventTypeId,
    int StatuId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    string? Description = null);
}