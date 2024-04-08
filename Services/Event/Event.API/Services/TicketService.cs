using AutoMapper;
using Event.API.Core;
using Event.API.Dtos.Tickets;
using Event.API.Entities;
using SharedLib.Dtos;

namespace Ticket.API.Service;

public class TicketService : ITicketService
{
    private readonly IGenericRepository<Tickety> _ticketRepository;
    private readonly IMapper _mapper;
    public TicketService(IGenericRepository<Tickety> ticketRepository,
        IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<AppResponse<CreatedTicketResponse>> CreateAsync(CreateTicketRequest request)
    {
        var entity = _mapper.Map<Tickety>(request);
        var ticket=await _ticketRepository.CreateAsync(entity);

        return AppResponse<CreatedTicketResponse>.Success(_mapper.Map<CreatedTicketResponse>(ticket), 201);
    }

    public async Task<AppResponse<NoContentResponse>> DeleteAsync(Guid id)
    {
        var ticket = await _ticketRepository.GetAsync(x=>x.Id==id);
        await _ticketRepository.DeleteAsync(ticket);
        return AppResponse<NoContentResponse>.Success(204);
    }

    public async Task<AppResponse<List<GetTicketResponse>>> GetAllAsync()
    {
        var tickets= await _ticketRepository.GetAllAsync();
        return AppResponse<List<GetTicketResponse>>.Success(_mapper.Map<List<GetTicketResponse>>(tickets), 200);
    }

    public async Task<AppResponse<GetTicketResponse>> GetByIdAsync(Guid id)
    {
        var ticket = await _ticketRepository.GetAsync(x=>x.Id==id);
        return AppResponse<GetTicketResponse>.Success(_mapper.Map<GetTicketResponse>(ticket), 200);
    }

    public async Task<AppResponse<UpdatedTicketResponse>> UpdateAsync(UpdateTicketRequest request, Guid id)
    {
        var ticket = await _ticketRepository.GetAsync(x=>x.Id==id);
        ticket.Name = request.Name;
        ticket.EventId = request.EventId;
        await _ticketRepository.UpdateAsync(ticket);

        return AppResponse<UpdatedTicketResponse>.Success(_mapper.Map<UpdatedTicketResponse>(ticket), 200);
    }
}
