using Joinlife.webui.Models.City;

namespace Joinlife.webui.Models.VenueDtos;

public sealed class GetVenueByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Line { get; set; }
    public int Capacity { get; set; }
    public string? ImageUrl { get; set; }
    public GetCityResponse City { get; set; }
}