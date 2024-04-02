using Location.Domain.Models.Response.Countries;

namespace Location.Domain.Models.Response.Cities;

public sealed class GetCityResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public GetCountryResponse Country { get; set; }
}
