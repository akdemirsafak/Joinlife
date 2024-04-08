using AutoMapper;
using Event.API.Entities;
using SharedLib.Dtos;

namespace Event.API.Services;
public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<AppResponse<CreatedEventResponse>> CreateAsync(CreateEventRequest request)
    {
        var entity = _mapper.Map<Eventy>(request);
        entity.CreatedAt = DateTime.Now;
        await _eventRepository.CreateAsync(entity);
        return AppResponse<CreatedEventResponse>.Success(_mapper.Map<CreatedEventResponse>(entity), 201);
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

    public async Task<AppResponse<GetEventReponse>> GetByIdAsync(Guid id)
    {
        var entity = await _eventRepository.GetAsync(x => x.Id == id);
        var getEventResponse = _mapper.Map<GetEventReponse>(entity);
        return AppResponse<GetEventReponse>.Success(getEventResponse, 200);
    }

    public async Task<AppResponse<UpdatedEventResponse>> UpdateAsync(UpdateEventRequest request, Guid id)
    {
        var entity = await _eventRepository.GetAsync(x => x.Id == id);
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.VenueId = request.VenueId;
        entity.StartDateTime = request.StartDateTime;
        entity.EndDateTime = request.EndDateTime;
        entity.Statu = (EventStatusEnum)request.StatuId;
        entity.Type = (EventTypeEnum)request.EventTypeId;
        entity.UpdatedAt = DateTime.Now;

        await _eventRepository.UpdateAsync(entity);
        return AppResponse<UpdatedEventResponse>.Success(_mapper.Map<UpdatedEventResponse>(entity), 200);
    }
}