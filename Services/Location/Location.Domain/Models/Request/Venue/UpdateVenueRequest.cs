namespace Location.Domain.Models.Request.Venue;
public sealed record UpdateVenueRequest(string Name, string Line, Guid CityId);