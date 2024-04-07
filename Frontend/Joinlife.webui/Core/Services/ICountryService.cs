using Joinlife.webui.Models.Country;

namespace Joinlife.webui.Core.Services
{
    public interface ICountryService
    {
        Task<List<CountryViewModel>> GetAllAsync();
        Task<GetCountryByIdResponse> GetByIdAsync(Guid id);
        Task CreateAsync(CreateCountryInput input);
        Task UpdateAsync(UpdateCountryInput input);
        Task DeleteAsync(Guid id);
    }
}