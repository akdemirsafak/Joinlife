namespace Location.Domain.Models.Response.Venue;
public sealed class GetVenueByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Line { get; set; }
    public string CityName { get; set; }
    public Guid CityId { get; set; }
}