namespace Joinlife.webui.Models.VenueDtos
{
    public sealed record UpdateVenueInput(Guid Id, string Name, string Line, Guid CityId);
}