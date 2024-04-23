using AutoMapper;
using Event.API.Core;
using Event.API.Dtos.Events;
using Event.API.Dtos.Tickets;
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


        var responseModel = new List<GetEventReponse>();

        foreach (var organization in events)
        {
            responseModel.Add(new GetEventReponse
            {
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,
                EventType = organization.Type.ToString(),
                EventTypeId = (int)organization.Type,
                ImageUrl = organization.ImageUrl,
                VenueId = organization.VenueId,
                StatuId = (int)organization.Statu,
                Statu = organization.Statu.ToString(),
                StartDateTime = organization.StartDateTime,
                EndDateTime = organization.EndDateTime,
                Tickets = organization.Tickets.Select(x => new EventTickets
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToList()
            });
        }
        //var responseModel = _mapper.Map<List<GetEventReponse>>(events);
        return AppResponse<List<GetEventReponse>>.Success(responseModel, 200);
    }

    public async Task<AppResponse<GetEventByIdResponse>> GetByIdAsync(Guid id)
    {
        var entity = await _eventRepository.GetAsync(x => x.Id == id);
        //var getEventResponse = _mapper.Map<GetEventByIdResponse>(entity);
        var getEventResponse= new GetEventByIdResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            EventType = entity.Type.ToString(),
            EventTypeId = (int)entity.Type,
            ImageUrl = entity.ImageUrl,
            VenueId = entity.VenueId,
            StatuId = (int)entity.Statu,
            Statu = entity.Statu.ToString(),
            StartDateTime = entity.StartDateTime,
            EndDateTime = entity.EndDateTime,
            CreatedAt = entity.CreatedAt,
            LastModifiedAt = entity.UpdatedAt,
            Tickets= entity.Tickets.Select(x=>new GetTicketResponse
            {
                Id=x.Id,
                Name=x.Name,
                Price=x.Price,
                EventId=x.Event.Id
            }).ToList()
        };
        return AppResponse<GetEventByIdResponse>.Success(getEventResponse, 200);
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