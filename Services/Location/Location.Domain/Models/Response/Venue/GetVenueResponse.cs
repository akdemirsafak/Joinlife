namespace Location.Domain.Models.Response.Venue;
public sealed class GetVenueResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Line { get; set; }
    public string CityName { get; set; }
}