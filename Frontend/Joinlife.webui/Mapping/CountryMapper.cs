using Joinlife.webui.Entities;
using Joinlife.webui.Models.Country;
using Riok.Mapperly.Abstractions;

namespace Joinlife.webui.Mapping
{
    [Mapper]
    public partial class CountryMapper
    {
        public partial List<GetCountryResponse> CountryListToGetCountryListResponse(List<Country> countries);
        public partial GetCountryByIdResponse CountryToGetCountryByIdResponse(Country country);
        public partial Country CreateCountryInputToCountry(CreateCountryInput country);
        public partial Country UpdateCountryInputToCountry(UpdateCountryInput country);
    }
}