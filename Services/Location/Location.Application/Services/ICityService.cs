using Location.Domain.Models.Request.Cities;
using Location.Domain.Models.Response.Cities;

namespace Location.Application.Services
{
    public interface ICityService
    {
        Task<List<GetCityResponse>> GetAllAsync();
        Task<GetCityResponse> GetByIdAsync(Guid id);
        Task<CreatedCityResponse> CreateAsync(CreateCityRequest request);
        Task<UpdatedCityResponse> UpdateAsync(UpdateCityRequest request, Guid id);
        Task DeleteAsync(Guid id);
    }
}
