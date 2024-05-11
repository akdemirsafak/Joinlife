using Location.Domain.Entities;
using Location.Domain.Models.Request.Countries;
using Location.Domain.Models.Response.Countries;
using Riok.Mapperly.Abstractions;

namespace Location.Persistance.Mapping;

[Mapper]
public partial class CountryMapper
{

    public partial Country CreateCountryRequestToCountry(CreateCountryRequest country);
    public partial CreatedCountryResponse CountryToCreatedCountryResponse(Country country);

    public partial List<GetCountryResponse> CountryListToGetCountryListResponse(List<Country> countries);
    public partial GetCountryResponse CountryToGetCountryResponse(Country country);

    public partial UpdatedCountryResponse CountryToUpdatedCountryResponse(Country country);
    public partial Country UpdateCountryRequestToCountry(UpdateCountryRequest country);

}
