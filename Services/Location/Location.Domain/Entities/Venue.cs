using Location.Domain.Abstract;

namespace Location.Domain.Entities;

public sealed class Venue : BaseEntity, IAuditableEntity
{
    public string Name { get; set; } = null!;
    public string? Line { get; set; }
    public City City { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
