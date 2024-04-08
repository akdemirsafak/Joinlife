namespace Location.Domain.Models.Request.Venue;

public sealed record CreateVenueRequest(string Name, string Line, Guid CityId);