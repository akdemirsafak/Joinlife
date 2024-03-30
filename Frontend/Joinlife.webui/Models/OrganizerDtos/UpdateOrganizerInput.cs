namespace Joinlife.webui.Models.OrganizerDtos
{
    public sealed record UpdateOrganizerInput(
        Guid Id,
        string Name,
        string Description
    );
}