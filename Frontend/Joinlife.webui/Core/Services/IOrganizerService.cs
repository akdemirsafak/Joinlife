
using Joinlife.webui.Models.OrganizerDtos;

namespace Joinlife.webui.Core.Services
{
    public interface IOrganizerService
    {
        Task<List<GetOrganizerResponse>> GetAllAsync();
        Task<GetOrganizerByIdResponse> GetByIdAsync(Guid id);
        Task CreateAsync(CreateOrganizerInput input);
        Task UpdateAsync(UpdateOrganizerInput input);
        Task DeleteAsync(Guid id);
    }
}