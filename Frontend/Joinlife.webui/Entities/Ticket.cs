namespace Joinlife.webui.Entities;

public sealed class Ticket : EntityBase, IAuditableEntity
{
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public TicketType Type { get; set; }
    public TicketStatus Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

}
public enum TicketStatus
{
    Open,
    Closed,
    Cancelled
}
public enum TicketType
{
    Vip = 1,
    Standart
}

