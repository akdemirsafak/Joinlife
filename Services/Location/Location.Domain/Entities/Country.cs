using Location.Domain.Abstract;

namespace Location.Domain.Entities;

public sealed class Country : BaseEntity, IAuditableEntity
{
    public string Name { get; set; } = null!;
    public ICollection<City>? Cities { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
