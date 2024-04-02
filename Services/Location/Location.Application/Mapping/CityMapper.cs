using Location.Domain.Entities;
using Location.Domain.Models.Request.Cities;
using Location.Domain.Models.Response.Cities;
using Riok.Mapperly.Abstractions;

namespace Location.Application.Mapping;

[Mapper]
public partial class CityMapper
{
    public partial City CreateCityRequestToCity(CreateCityRequest createCityRequest);
    public partial CreatedCityResponse CityToCreatedCityResponse(City city);
    public partial List<GetCityResponse> CityListToGetCityResponseList(List<City> cities);
    public partial GetCityResponse CityToGetCityResponse(City city);
    public partial UpdatedCityResponse CityToUpdatedCityResponse(City city);
}
