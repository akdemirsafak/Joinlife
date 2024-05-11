using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.VenueDtos;
using Joinlife.webui.Utilities;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public class VenueService : IVenueService
{
    private readonly HttpClient _httpClient;
    private readonly IFileService _fileService;
    //Service Requests
    public VenueService(HttpClient httpClient, IFileService fileService)
    {
        _httpClient = httpClient;
        _fileService = fileService;
    }

    public async Task CreateAsync(CreateVenueInput input)
    {
        var imageUrl = await _fileService.UploadImageAsync(input.Image, containerName: ContainerNames.Venue);
        input.ImageUrl = imageUrl;
        var clientResult = await _httpClient.PostAsJsonAsync("venue", input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("İlgili alan oluşturulamadı.");
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var clientResult = await _httpClient.DeleteAsync($"venue/{id}");
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Etkinlik alanı silinemedi.");
        }

    }
    public async Task<List<GetVenueResponse>> GetAllAsync()
    {
        var clientResult = await _httpClient.GetAsync("venue");
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Etkinlik alanları getirilemiyor.");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<AppResponse<List<GetVenueResponse>>>();
        return result.Data;
    }

    public async Task<GetVenueByIdResponse> GetByIdAsync(Guid id)
    {
        var clientResult= await _httpClient.GetAsync($"venue/{id}");
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Etkinlik alanı getirilirken bir problem yaşandı.");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetVenueByIdResponse>>();
        var data= result.Data;
        return data;
    }

    public async Task UpdateAsync(UpdateVenueInput input)
    {

        var imageUrl = await _fileService.UploadImageAsync(input.Image, containerName: ContainerNames.Venue);
        input.ImageUrl = imageUrl;

        var clientResult = await _httpClient.PutAsJsonAsync($"venue/{input.Id}", input);

        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Etkinlik alanı güncellenemedi.");
        }
        var venue= clientResult.Content.ReadFromJsonAsync<AppResponse<GetVenueResponse>>();
    }
}