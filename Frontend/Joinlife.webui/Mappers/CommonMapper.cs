using Joinlife.webui.Models.EventDtos;
using Joinlife.webui.Models.VenueDtos;
using Riok.Mapperly.Abstractions;

namespace Joinlife.webui.Mappers;

[Mapper]
public partial class CommonMapper
{
    public partial UpdateEventInput GetEventByIdResponseToUpdateEventInput(GetEventByIdResponse getEventByIdResponse);

    public partial UpdateVenueInput GetVenueByIdResponseToUpdateVenueInput(GetVenueByIdResponse getVenueByIdResponse);
}
