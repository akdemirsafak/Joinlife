using Mapster;
using SharedLib.Dtos;
using Ticket.API.Models;
using Ticket.API.Repository;

namespace Ticket.API.Service;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<AppResponse<CreatedTicketResponse>> CreateAsync(CreateTicketRequest request)
    {
        var entity = request.Adapt<Entity.Ticket>();
        await _ticketRepository.CreateAsync(entity);

        return AppResponse<CreatedTicketResponse>.Success(entity.Adapt<CreatedTicketResponse>(),201);
    }

    public async Task<AppResponse<NoContentResponse>> DeleteAsync(Guid id)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id);
        await _ticketRepository.DeleteAsync(ticket);
        return AppResponse<NoContentResponse>.Success(204);
    }

    public async Task<AppResponse<List<GetTicketResponse>>> GetAllAsync()
    {
        var tickets= await _ticketRepository.GetAllAsync();
        return AppResponse<List<GetTicketResponse>>.Success(tickets.Adapt<List<GetTicketResponse>>(),200);
    }

    public async Task<AppResponse<GetTicketResponse>> GetByIdAsync(Guid id)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id);
        return AppResponse<GetTicketResponse>.Success(ticket.Adapt<GetTicketResponse>(), 200);
    }

    public async Task<AppResponse<UpdatedTicketResponse>> UpdateAsync(UpdateTicketRequest request, Guid id)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id);
        ticket.Name = request.Name;
        ticket.EventId = request.EventId;
        await _ticketRepository.UpdateAsync(ticket);

        return AppResponse<UpdatedTicketResponse>.Success(ticket.Adapt<UpdatedTicketResponse>(), 200);
    }
}
