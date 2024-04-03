using SharedLib.Dtos;
using Ticket.API.Models;

namespace Ticket.API.Service;

public interface ITicketService
{
    Task<AppResponse<List<GetTicketResponse>>> GetAllAsync();
    Task<AppResponse<GetTicketResponse>> GetByIdAsync(Guid id);
    Task<AppResponse<CreatedTicketResponse>> CreateAsync(CreateTicketRequest request);
    Task<AppResponse<UpdatedTicketResponse>> UpdateAsync(UpdateTicketRequest request, Guid id);
    Task<AppResponse<NoContentResponse>> DeleteAsync(Guid id);
}
