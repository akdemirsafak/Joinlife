namespace Location.Domain.Models.Request.Countries;

public sealed record UpdateCountryRequest(string Name, string? ImageUrl);