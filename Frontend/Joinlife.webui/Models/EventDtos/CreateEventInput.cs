using System.ComponentModel;

namespace Joinlife.webui.Models.EventDtos
{
    public class CreateEventInput
    {
        [DisplayName("Etkinliğin Adı")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string? Description { get; set; }
        public int EventTypeId { get; set; }
        public Guid OrganizerId { get; set; }
        public Guid VenueId { get; set; }
    }
}