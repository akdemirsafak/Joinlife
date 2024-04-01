using Joinlife.webui.Models.VenueDtos;

namespace Joinlife.webui.Core.Services
{
    public interface IVenueService
    {
        Task CreateAsync(CreateVenueInput input);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(UpdateVenueInput input);
        Task<List<GetVenueResponse>> GetAllAsync();
        Task<GetVenueByIdResponse> GetByIdAsync(Guid id);
    }
}