using Joinlife.webui.Core.Services;
using Joinlife.webui.Models.Country;
using Joinlife.webui.Utilities;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;
    private readonly IFileService _fileService;
    //Service Requests
    public CountryService(HttpClient httpClient, IFileService fileService)
    {
        _httpClient = httpClient;
        _fileService = fileService;
    }

    public async Task CreateAsync(CreateCountryInput input)
    {
        var imageUrl= await _fileService.UploadImageAsync(input.Image, containerName:ContainerNames.Country);
        input.ImageUrl = imageUrl;
        var clientResult= await _httpClient.PostAsJsonAsync("country",input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Ülkeyi kaydederken bir problem oluştu.");
        }
        //var responseContent = await clientResult.Content.ReadFromJsonAsync<AppResponse<CountryViewModel>>();
    }

    public async Task DeleteAsync(Guid id)
    {
        //Country'de delete yok.
        //var clientResult = await _httpClient.DeleteAsync($"country/{id}"); 
        // if (!clientResult.IsSuccessStatusCode)
        // {
        //     throw new Exception("delete country failed");
        // }
    }

    public async Task<List<CountryViewModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("country");
        if (!response.IsSuccessStatusCode)
        {
            return new List<CountryViewModel>();
        }

        var countryResponse = await response.Content.ReadFromJsonAsync<AppResponse<List<CountryViewModel>>>();
        //ReadString ile data geliyor. maplemede sıkıntı var büyük ihtimalle
        return countryResponse.Data;
    }

    public async Task<GetCountryByIdResponse> GetByIdAsync(Guid id)
    {
        var clientResult = await _httpClient.GetAsync($"country/{id}");
        var responseContent= await clientResult.Content.ReadFromJsonAsync<AppResponse<GetCountryByIdResponse>>();
        return responseContent.Data;
    }

    public async Task UpdateAsync(UpdateCountryInput input)
    {
        var imageUrl= await _fileService.UploadImageAsync(input.Image,containerName:ContainerNames.Country);
        input.ImageUrl = imageUrl;

        var clientResult = await _httpClient.PutAsJsonAsync($"country/{input.Id}", input);
        if (!clientResult.IsSuccessStatusCode)
        {
            throw new Exception("Ülke bilgileri güncellenemedi.");
        }
        //var requestContent = await clientResult.Content.ReadFromJsonAsync<AppResponse<GetCountryResponse>>();

    }
}