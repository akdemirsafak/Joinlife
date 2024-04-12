namespace Event.API.Dtos.Events
{
    public record CreateEventRequest(
    string Name,
    Guid VenueId,
    int EventTypeId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    string ImageUrl,
    int StatuId = 1,
    string? Description = null);
}