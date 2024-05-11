using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.City;
using Joinlife.webui.Utilities;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public class CityService : ICityService
{
    private readonly HttpClient _httpClient;
    private readonly IFileService _fileService;
    //Service Requests

    public CityService(HttpClient httpClient, IFileService fileService)
    {
        _httpClient = httpClient;
        _fileService = fileService;
    }

    public async Task CreateAsync(CreateCityInput input)
    {
        var imageUrl= await _fileService.UploadImageAsync(input.Image, containerName:ContainerNames.City);
        input.ImageUrl = imageUrl;
        var clientResult= await _httpClient.PostAsJsonAsync($"city", input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Şehir kaydedilirken bir problem oluştu.");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<GetCityResponse>();
    }

    public async Task DeleteAsync(Guid id)
    {
        var request= await _httpClient.DeleteAsync($"city/{id}");
    }

    public async Task<List<GetCityResponse>> GetAllAsync()
    {
        var clientResult= await _httpClient.GetAsync("city");
        var cities = await clientResult.Content.ReadFromJsonAsync<AppResponse<List<GetCityResponse>>>();
        return cities.Data;
    }

    public async Task<GetCityResponse> GetAsync(Guid id)
    {
        var clientResult= await _httpClient.GetAsync($"city/{id}");
        var city = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetCityResponse>>();
        return city.Data;
    }

    public async Task UpdateAsync(UpdateCityInput input)
    {

        var imageUrl= await _fileService.UploadImageAsync(input.Image,containerName:ContainerNames.City);
        input.ImageUrl = imageUrl;

        var clientResult= await _httpClient.PutAsJsonAsync($"city/{input.Id}", input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Şehir güncellenirken bir problem oluştu.");
        }
        var result = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetCityResponse>>();
    }
}