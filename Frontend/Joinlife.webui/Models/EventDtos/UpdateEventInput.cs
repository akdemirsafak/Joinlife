namespace Joinlife.webui.Models.EventDtos
{
    public sealed record UpdateEventInput(
        Guid Id,
        string Name,
        string Description,
        int EventTypeId,
        Guid OrganizerId,
        Guid VenueId);
}