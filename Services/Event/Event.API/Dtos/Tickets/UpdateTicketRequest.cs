namespace Event.API.Dtos.Tickets;

public record UpdateTicketRequest(
    string Name,
    decimal Price,
    Guid EventId);