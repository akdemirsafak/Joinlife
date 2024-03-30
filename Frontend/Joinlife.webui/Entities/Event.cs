namespace Joinlife.webui.Entities;

public sealed class Event : EntityBase, IAuditableEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public EventTypeEnum EventType { get; set; }
    public Organizer Organizer { get; set; } //Event'i düzenleyen firma
    public Venue Venue { get; set; } //Nerede
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}

public enum EventTypeEnum
{
    Concert = 1,
    Festival = 2,
    Party = 3,
    Workshop = 4,
    Other = 5
}
