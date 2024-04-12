using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.EventDtos;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public sealed class EventService : IEventService
{
    private readonly IFileService _fileService;
    private readonly HttpClient _httpClient;
    //Service Requests
    public EventService(HttpClient httpClient, IFileService fileService)
    {
        _httpClient = httpClient;
        _fileService = fileService;
    }

    public async Task CreateAsync(CreateEventInput input)
    {
        var imageUrl= await _fileService.UploadImageAsync(input.Image,"event");
        input.ImageUrl = imageUrl;

        var clientResult = await _httpClient.PostAsJsonAsync("event", input);

        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Could not create event");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetEventResponse>>();
    }

    public async Task DeleteAsync(Guid id)
    {
        var clientResult = await _httpClient.DeleteAsync($"event/{id}");
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Country cannot delete.");
        }
    }

    public async Task<List<GetEventResponse>> GetAllAsync()
    {
        var clientResult = await _httpClient.GetAsync("event");
        var content = await clientResult.Content.ReadFromJsonAsync<AppResponse<List<GetEventResponse>>>();
        return content.Data;
    }

    public async Task<GetEventByIdResponse> GetAsync(Guid id)
    {
        var clientResult = await _httpClient.GetAsync($"event/{id}");
        var responseContent = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetEventByIdResponse>>();
        return responseContent.Data;

    }

    public async Task UpdateAsync(UpdateEventInput input)
    {
        var clientResult = await _httpClient.PutAsJsonAsync($"event/{input.Id}", input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Country cannot update.");
        }
    }
}