using Joinlife.webui.Models.City;

namespace Joinlife.webui.Core.Services
{
    public interface ICityService
    {
        Task<List<GetCityResponse>> GetAllAsync();
        Task<GetCityResponse> GetAsync(Guid id);
        Task CreateAsync(CreateCityInput input);
        Task UpdateAsync(UpdateCityInput input);
        Task DeleteAsync(Guid id);
    }
}