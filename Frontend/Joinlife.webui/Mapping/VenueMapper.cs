using Joinlife.webui.Entities;
using Joinlife.webui.Models.VenueDtos;
using Riok.Mapperly.Abstractions;

namespace Joinlife.webui.Mapping
{
    [Mapper]
    public partial class VenueMapper
    {
        [MapProperty(nameof(Venue.City.Name), nameof(GetVenueResponse.CityName))]
        public partial List<GetVenueResponse> VenueListToGetVenueResponseList(List<Venue> venues);

        [MapProperty(nameof(Venue.City.Name), nameof(GetVenueByIdResponse.CityName))]
        [MapProperty(nameof(Venue.City.Id), nameof(GetVenueByIdResponse.CityId))]
        public partial GetVenueByIdResponse VenueToGetVenueByIdResponse(Venue venue);
    }
}