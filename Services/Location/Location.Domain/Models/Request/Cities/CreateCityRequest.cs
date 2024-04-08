namespace Location.Domain.Models.Request.Cities;

public sealed record CreateCityRequest(string Name, Guid CountryId);