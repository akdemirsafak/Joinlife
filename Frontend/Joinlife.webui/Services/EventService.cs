using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.EventDtos;
using Joinlife.webui.Utilities;
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
        var imageUrl = await _fileService.UploadImageAsync(input.Image, containerName: ContainerNames.Event);
        input.ImageUrl = imageUrl;

        var clientResult = await _httpClient.PostAsJsonAsync("event", input);

        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Etkinlik oluşturulamadı.");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetEventResponse>>();
    }

    public async Task DeleteAsync(Guid id)
    {
        var clientResult = await _httpClient.DeleteAsync($"event/{id}");
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Etkinlik silinemedi.");
        }
    }

    public async Task<List<GetEventResponse>> GetAllAsync()
    {
        var clientResult = await _httpClient.GetAsync("event");
        var content = await clientResult.Content.ReadFromJsonAsync<AppResponse<IEnumerable<GetEventResponse>>>();
        var data = content.Data.OrderBy(x => x.StatuId).OrderByDescending(x => x.StartDateTime.Ticks).ToList();
        return data;
    }

    public async Task<GetEventByIdResponse> GetAsync(Guid id)
    {
        var clientResult = await _httpClient.GetAsync($"event/{id}");
        var responseContent = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetEventByIdResponse>>();
        return responseContent.Data;

    }

    public async Task UpdateAsync(UpdateEventInput input)
    {
        var imageUrl = await _fileService.UploadImageAsync(input.Image, containerName: ContainerNames.Event);
        input.ImageUrl = imageUrl;
        var clientResult = await _httpClient.PutAsJsonAsync($"event/{input.Id}", input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Etkinlik güncellenemedi.");
        }
    }
}