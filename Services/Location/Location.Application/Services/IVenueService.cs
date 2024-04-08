using Location.Domain.Models.Request.Venue;
using Location.Domain.Models.Response.Venue;

namespace Location.Application.Services;

public interface IVenueService
{
    Task<CreatedVenueResponse> CreateAsync(CreateVenueRequest request);
    Task DeleteAsync(Guid id);
    Task<UpdatedVenueResponse> UpdateAsync(UpdateVenueRequest request, Guid id);
    Task<List<GetVenueResponse>> GetAllAsync();
    Task<GetVenueByIdResponse> GetByIdAsync(Guid id);
}
