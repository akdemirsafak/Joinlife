namespace Location.Domain.Models.Request.Cities;

public sealed record UpdateCityRequest(string Name, Guid CountryId, string? ImageUrl);
