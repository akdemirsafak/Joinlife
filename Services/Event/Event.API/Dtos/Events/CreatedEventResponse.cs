namespace Event.API.Dtos.Events;
public class CreatedEventResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string EventType { get; set; }
    public int EventTypeId { get; set; }
    public string Statu { get; set; }
    public int StatuId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}