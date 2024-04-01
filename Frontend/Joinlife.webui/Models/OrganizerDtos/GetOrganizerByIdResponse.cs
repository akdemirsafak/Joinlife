using Joinlife.webui.Entities;

namespace Joinlife.webui.Models.OrganizerDtos
{
    public sealed class GetOrganizerByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}