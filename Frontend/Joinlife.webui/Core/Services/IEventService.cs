using Joinlife.webui.Models.EventDtos;

namespace Joinlife.webui.Core.Services
{
    public interface IEventService
    {
        Task<List<GetEventResponse>> GetAllAsync();
        Task<GetEventByIdResponse> GetAsync(Guid id);
        Task CreateAsync(CreateEventInput input);
        Task UpdateAsync(UpdateEventInput input);
        Task DeleteAsync(Guid id);
    }
}