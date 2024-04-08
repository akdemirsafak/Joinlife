namespace Joinlife.webui.Models.EventDtos;

public sealed record UpdateEventInput(
    Guid Id,
    string Name,
    string Description,
    int EventTypeId,
    Guid VenueId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    int StatuId);