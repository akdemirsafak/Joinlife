namespace Event.API.Dtos.Events;
public record UpdateEventRequest(
    string Name,
    Guid VenueId,
    int EventTypeId,
    int StatuId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    string? ImageUrl = null,
    string? Description = null);