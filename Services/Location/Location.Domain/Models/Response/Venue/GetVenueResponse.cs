using Location.Domain.Models.Response.Cities;

namespace Location.Domain.Models.Response.Venue;
public sealed class GetVenueResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Line { get; set; }
    public GetCityResponse City { get; set; }
    public int Capacity { get; set; }
    public string? ImageUrl { get; set; }
}