namespace Location.Domain.Models.Response.Countries;

public sealed class GetCountryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}