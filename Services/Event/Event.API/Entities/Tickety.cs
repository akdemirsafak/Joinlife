using System.ComponentModel.DataAnnotations;

namespace Event.API.Entities;

public sealed class Tickety
{
    public Guid Id { get; set; }
    [Required, Length(2, 32)]
    public string Name { get; set; } = null!;
    public Guid EventId { get; set; }
    public Eventy Event { get; set; } = null!;
    [DataType("decimal(18,2)")]
    public decimal Price { get; set; }

    public Tickety()
    {
        Id = Guid.NewGuid();
    }
}
