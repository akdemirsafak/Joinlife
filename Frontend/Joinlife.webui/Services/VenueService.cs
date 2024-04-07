using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.VenueDtos;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public class VenueService : IVenueService
{
    private readonly HttpClient _httpClient;

    public VenueService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAsync(CreateVenueInput input)
    {
        var clientResult = await _httpClient.PostAsJsonAsync("venue", input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Could not create venue");
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var clientResult = await _httpClient.DeleteAsync($"venue/{id}");
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Country cannot delete.");
        }

    }
    public async Task<List<GetVenueResponse>> GetAllAsync()
    {
        var clientResult = await _httpClient.GetAsync("venue");
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Could not get venues");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<AppResponse<List<GetVenueResponse>>>();
        return result.Data;
    }

    public async Task<GetVenueByIdResponse> GetByIdAsync(Guid id)
    {
        var clientResult= await _httpClient.GetAsync($"venue/{id}");
        if (!clientResult.IsSuccessStatusCode)
        { 
            throw new Exception("Could not get venue");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetVenueByIdResponse>>();
        return result.Data;
    }

    public async Task UpdateAsync(UpdateVenueInput input)
    {
        var clientResult = await _httpClient.PutAsJsonAsync($"venue/{input.Id}", input);

        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Could not update venue");
        }
        var venue= clientResult.Content.ReadFromJsonAsync<AppResponse<GetVenueResponse>>();
    }
}