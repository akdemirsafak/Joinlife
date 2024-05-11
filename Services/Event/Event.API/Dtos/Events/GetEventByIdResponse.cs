using Event.API.Dtos.Tickets;
using System.ComponentModel;

namespace Event.API.Dtos.Events;

public class GetEventByIdResponse
{
    public Guid Id { get; set; }
    [DisplayName("Etkinlik Adı")]
    public string Name { get; set; }
    [DisplayName("Açıklama")]
    public string? Description { get; set; }
    public string EventType { get; set; }
    public int EventTypeId { get; set; }
    public string? ImageUrl { get; set; }
    public Guid VenueId { get; set; } //Nerede
    public int StatuId { get; set; } = 1;
    public string Statu { get; set; }
    public List<GetTicketResponse> Tickets { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
