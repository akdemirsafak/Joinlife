using Location.Domain.Models.Request.Countries;
using Location.Domain.Models.Response.Countries;

namespace Location.Application.Services;

public interface ICountryService
{
    Task<List<GetCountryResponse>> GetAllAsync();
    Task<GetCountryResponse> GetByIdAsync(Guid id);
    Task<CreatedCountryResponse> CreateAsync(CreateCountryRequest request);
    Task<UpdatedCountryResponse> UpdateAsync(UpdateCountryRequest request, Guid id);
    Task DeleteAsync(Guid id);
}
