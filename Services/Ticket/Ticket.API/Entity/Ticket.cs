using System.ComponentModel.DataAnnotations;

namespace Ticket.API.Entity;

public class Ticket
{
    public Guid Id { get; set; }
    [Required,Length(2,32)]
    public string Name { get; set; } = null!;
    public Guid EventId { get; set; }
    [DataType("decimal(18,2)")]
    public decimal Price { get; set; }

    public Ticket()
    {
        Id = Guid.NewGuid();
    }
}
