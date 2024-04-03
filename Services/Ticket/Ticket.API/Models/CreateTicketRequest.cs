using System.ComponentModel.DataAnnotations;

namespace Ticket.API.Models;

public record CreateTicketRequest(
    [Required,Length(2,32)]
    string Name,
    decimal Price,
    Guid EventId);