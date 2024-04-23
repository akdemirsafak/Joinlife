using File.API.Models;

namespace File.API.Services;

public interface IImageService
{
    Task<string> UploadImageAsync(IFormFile file,string containerName);
    Task<bool> DeleteImageAsync(string fileName, string containerName);
}
