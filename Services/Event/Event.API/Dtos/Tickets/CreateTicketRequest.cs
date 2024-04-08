namespace Event.API.Dtos.Tickets;

public record CreateTicketRequest(
    string Name,
    decimal Price,
    Guid EventId);