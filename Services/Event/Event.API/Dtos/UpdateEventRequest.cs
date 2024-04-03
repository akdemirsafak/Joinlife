namespace Event.API.Dtos;
public record UpdateEventRequest(
    string Name,
    Guid VenueId,
    int EventTypeId,
    int StatuId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    string? Description = null);