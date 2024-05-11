using Location.Domain.Models.Response.Cities;

namespace Location.Domain.Models.Response.Venue;
public sealed class GetVenueByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Line { get; set; }
    public int Capacity { get; set; }
    public string? ImageUrl { get; set; }
    public GetCityResponse City { get; set; }
}