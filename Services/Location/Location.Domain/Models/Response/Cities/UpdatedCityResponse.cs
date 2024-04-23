namespace Location.Domain.Models.Response.Cities;

public sealed class UpdatedCityResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
}
