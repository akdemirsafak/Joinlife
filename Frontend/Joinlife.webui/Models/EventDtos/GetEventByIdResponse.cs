using System.ComponentModel;

namespace Joinlife.webui.Models.EventDtos
{
    public sealed class GetEventByIdResponse
    {
        public Guid Id { get; set; }
        [DisplayName("Etkinlik Adı")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string? Description { get; set; }
        public string EventType { get; set; }
        public int EventTypeId { get; set; }
        public Organizer Organizer { get; set; } //Event'i düzenleyen firma
        public Venue Venue { get; set; } //Nerede
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
