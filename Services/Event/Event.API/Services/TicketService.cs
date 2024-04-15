using AutoMapper;
using Event.API.Core;
using Event.API.Dtos.Tickets;
using Event.API.Entities;
using SharedLib.Dtos;

namespace Ticket.API.Service;

public class TicketService : ITicketService
{
    private readonly IGenericRepository<Tickety> _ticketRepository;
    private readonly IGenericRepository<Eventy> _eventRepository;
    private readonly IMapper _mapper;
    public TicketService(IGenericRepository<Tickety> ticketRepository,
        IGenericRepository<Eventy> eventRepository,
        IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _eventRepository = eventRepository;
        _mapper = mapper;    
    }

    public async Task<AppResponse<CreatedTicketResponse>> CreateAsync(CreateTicketRequest request)
    {
        var ticketEntity = _mapper.Map<Tickety>(request);
        var eventy= await _eventRepository.GetAsync(x=>x.Id==request.EventId);
        ticketEntity.Event = eventy;
        var ticket=await _ticketRepository.CreateAsync(ticketEntity);

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
        if (ticket is null)
        {
            return AppResponse<UpdatedTicketResponse>.Fail("", 404);
        }
        var eventy = await _eventRepository.GetAsync(x=>x.Id==request.EventId);
        ticket.Name = request.Name;
        ticket.Event=eventy;
        await _ticketRepository.UpdateAsync(ticket);

        return AppResponse<UpdatedTicketResponse>.Success(_mapper.Map<UpdatedTicketResponse>(ticket), 200);
    }
}
