namespace Joinlife.webui.Models.Tickets;

public record UpdateTicketInput(Guid id,string Name,decimal Price,Guid eventId);