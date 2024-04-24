using Location.Domain.Entities;
using Location.Domain.Models.Request.Venue;
using Location.Domain.Models.Response.Venue;
using Riok.Mapperly.Abstractions;


namespace Location.Persistance.Mapping;

[Mapper]
public partial class VenueMapper
{

    public partial List<GetVenueResponse> VenueListToGetVenueResponseList(List<Venue> venues);

    //[MapProperty(nameof(Venue.City.Name), nameof(GetVenueByIdResponse.CityName))]
    //[MapProperty(nameof(Venue.City.Id), nameof(GetVenueByIdResponse.CityId))]
    public partial GetVenueByIdResponse VenueToGetVenueByIdResponse(Venue venue);

    public partial Venue CreateVenueRequestToVenue(CreateVenueRequest request);

    public partial CreatedVenueResponse VenueToCreatedVenueResponse(Venue venue);
    public partial UpdatedVenueResponse VenueToUpdatedVenueResponse(Venue venue);
}