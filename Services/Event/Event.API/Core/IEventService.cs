using Event.API.Dtos.Events;
using SharedLib.Dtos;

namespace Event.API.Core;

public interface IEventService
{
    Task<AppResponse<List<GetEventReponse>>> GetAllAsync();
    Task<AppResponse<GetEventByIdResponse>> GetByIdAsync(Guid id);
    Task<AppResponse<CreatedEventResponse>> CreateAsync(CreateEventRequest request);
    Task<AppResponse<UpdatedEventResponse>> UpdateAsync(UpdateEventRequest request, Guid id);
    Task<AppResponse<NoContentResponse>> DeleteAsync(Guid id);
}