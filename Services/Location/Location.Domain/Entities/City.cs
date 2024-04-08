using Location.Domain.Abstract;

namespace Location.Domain.Entities;

public sealed class City : BaseEntity, IAuditableEntity
{
    public string Name { get; set; } = null!;
    public Country Country { get; set; } = null!;
    public ICollection<Venue> Venues { get ; set ; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
