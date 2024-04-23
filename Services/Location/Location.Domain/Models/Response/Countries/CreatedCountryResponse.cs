namespace Location.Domain.Models.Response.Countries;

public sealed class CreatedCountryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
}
