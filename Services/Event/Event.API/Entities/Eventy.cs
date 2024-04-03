namespace Event.API.Entities;

public sealed class Eventy
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public EventTypeEnum Type { get; set; }
    public Guid VenueId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EventStatusEnum Statu { get; set; }


    public Eventy()
    {
        Id = Guid.NewGuid();
    }
}
public enum EventTypeEnum
{
    Concert = 1,
    Festival,
    Party,
    Sport,
    Comedy,
    Workshop,
    Opera,
    Other
}

public enum EventStatusEnum
{
    Active = 1,
    Cancelled,
    Postpone,
    Finished
}
