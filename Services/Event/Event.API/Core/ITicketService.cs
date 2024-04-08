using Event.API.Dtos.Tickets;
using SharedLib.Dtos;

namespace Event.API.Core;

public interface ITicketService
{
    Task<AppResponse<List<GetTicketResponse>>> GetAllAsync();
    Task<AppResponse<GetTicketResponse>> GetByIdAsync(Guid id);
    Task<AppResponse<CreatedTicketResponse>> CreateAsync(CreateTicketRequest request);
    Task<AppResponse<UpdatedTicketResponse>> UpdateAsync(UpdateTicketRequest request, Guid id);
    Task<AppResponse<NoContentResponse>> DeleteAsync(Guid id);
}
