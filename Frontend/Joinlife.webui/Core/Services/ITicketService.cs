using Joinlife.webui.Models.Tickets;

namespace Joinlife.webui.Core.Services;

public interface ITicketService
{
    Task<List<TicketViewModel>> GetEventTickets(Guid eventId);
    Task<TicketViewModel> GetById(Guid ticketId);
    Task<TicketViewModel> CreateAsync(CreateTicketInput createTicketInput);
    Task<TicketViewModel> UpdateAsync(UpdateTicketInput updateTicketInput);

}
