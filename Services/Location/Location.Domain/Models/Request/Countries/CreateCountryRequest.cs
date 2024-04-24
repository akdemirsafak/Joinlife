namespace Location.Domain.Models.Request.Countries;

public sealed record CreateCountryRequest(string Name, string? ImageUrl);