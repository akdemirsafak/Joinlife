using Joinlife.webui.Entities;
using Joinlife.webui.Models.OrganizerDtos;
using Riok.Mapperly.Abstractions;

namespace Joinlife.webui.Mapping
{
    [Mapper]
    public partial class OrganizerMapper
    {
        public partial GetOrganizerByIdResponse OrganizerToGetOrganizerByIdResponse(Organizer organizer);
        public partial List<GetOrganizerResponse> OrganizerListToGetOrganizerResponseList(List<Organizer> organizers);

        public partial Organizer CreateOrganizerInputToOrganizer(CreateOrganizerInput organizer);
        public partial Organizer UpdateOrganizerInputToOrganizer(UpdateOrganizerInput organizer);
    }
}