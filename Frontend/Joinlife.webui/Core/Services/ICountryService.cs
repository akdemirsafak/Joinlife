using Joinlife.webui.Models.Country;

namespace Joinlife.webui.Core.Services
{
    public interface ICountryService
    {
        Task<List<GetCountryResponse>> GetAllAsync();
        Task<GetCountryResponse> GetAsync(Guid id);
        Task CreateAsync(CreateCountryInput input);
        Task UpdateAsync(UpdateCountryInput input);
        Task DeleteAsync(Guid id);
    }
}