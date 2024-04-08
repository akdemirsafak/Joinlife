using Joinlife.webui.Models.Country;

namespace Joinlife.webui.Models.City;

public class GetCityResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CountryViewModel Country { get; set; }
}