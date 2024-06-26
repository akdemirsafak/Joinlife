using AutoMapper;
using Event.API.Core;
using Event.API.Dtos.Events;
using Event.API.Entities;
using SharedLib.Dtos;

namespace Event.API.Services;
public class EventService : IEventService
{
    private readonly IGenericRepository<Eventy> _eventRepository;
    private readonly IMapper _mapper;

    public EventService(IGenericRepository<Eventy> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }


    public async Task<AppResponse<CreatedEventResponse>> CreateAsync(CreateEventRequest request)
    {
        var entity = _mapper.Map<Eventy>(request);
        entity.CreatedAt = DateTime.Now;
        var response= await _eventRepository.CreateAsync(entity);
        return AppResponse<CreatedEventResponse>.Success(_mapper.Map<CreatedEventResponse>(response), 201);
    }

    public async Task<AppResponse<NoContentResponse>> DeleteAsync(Guid id)
    {
        var entity = await _eventRepository.GetAsync(x => x.Id == id);
        await _eventRepository.DeleteAsync(entity);
        return AppResponse<NoContentResponse>.Success(204);
    }

    public async Task<AppResponse<List<GetEventReponse>>> GetAllAsync()
    {
        var events = await _eventRepository.GetAllAsync();

        var responseModel = _mapper.Map<List<GetEventReponse>>(events);
 
        return AppResponse<List<GetEventReponse>>.Success(responseModel, 200);
    }

    public async Task<AppResponse<GetEventByIdResponse>> GetByIdAsync(Guid id)
    {
        var entity = await _eventRepository.GetAsync(x => x.Id == id);

        var getEventResponse = _mapper.Map<GetEventByIdResponse>(entity);
        return AppResponse<GetEventByIdResponse>.Success(getEventResponse, 200);
    }

    public async Task<AppResponse<UpdatedEventResponse>> UpdateAsync(UpdateEventRequest request, Guid id)
    {
        var entity = await _eventRepository.GetAsync(x => x.Id == id);
        _mapper.Map(request, entity);

        await _eventRepository.UpdateAsync(entity);
        return AppResponse<UpdatedEventResponse>.Success(_mapper.Map<UpdatedEventResponse>(entity), 200);
    }
}