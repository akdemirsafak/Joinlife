using Joinlife.webui.Core.Services;
using SharedLib.Dtos;

namespace Joinlife.webui.Services;

public sealed class FileService : IFileService
{
    private readonly HttpClient _httpClient;

    public FileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> UploadImageAsync(IFormFile photo,string containerName)
    {

        if (photo == null || photo.Length <= 0)
        {
            return null;
        }
        // örnek dosya ismi= 203802340234.jpg
        var randomFilename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";
        using var ms = new MemoryStream();
        await photo.CopyToAsync(ms);
        var multipartContent = new MultipartFormDataContent();
        multipartContent.Add(new ByteArrayContent(ms.ToArray()), "photo", randomFilename);
        //multipartContent.Add(new StringContent(containerName), "containerName");
        

        var clientResponse= await _httpClient.PostAsync("photostock",multipartContent);
        if(!clientResponse.IsSuccessStatusCode)
        {
            return null;
        }
        var fileContent = await clientResponse.Content.ReadFromJsonAsync<AppResponse<string>>();
        var fileName=fileContent.Data;
        return fileName;
    }
}
