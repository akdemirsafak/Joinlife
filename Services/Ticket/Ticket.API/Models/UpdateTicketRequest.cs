using System.ComponentModel.DataAnnotations;

namespace Ticket.API.Models;

public record UpdateTicketRequest(
    [Required,Length(2,32)]
    string Name,
    decimal Price,
    Guid EventId);