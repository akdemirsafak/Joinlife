namespace Joinlife.webui.Models.Tickets;
public record CreateTicketInput(string Name, decimal Price, Guid EventId);