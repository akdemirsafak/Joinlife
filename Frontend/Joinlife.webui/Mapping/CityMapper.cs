using Joinlife.webui.Entities;
using Joinlife.webui.Models.City;
using Riok.Mapperly.Abstractions;

namespace Joinlife.webui.Mapping
{
    [Mapper]
    public partial class CityMapper
    {
        public partial City CityToCreateCityInput(CreateCityInput input);
        public partial City CityToUpdateCityInput(UpdateCityInput input);
        public partial List<GetCityResponse> CityListToGetCityListResponse(List<City> cities);
        public partial GetCityResponse CityToGetCityResponse(City city);

    }
}