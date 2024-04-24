namespace Joinlife.webui.Core.Services;

public interface IFileService
{
    Task<string> UploadImageAsync(IFormFile photo, string containerName);
    Task<bool> DeleteImageAsync(string fileName, string containerName);
}
