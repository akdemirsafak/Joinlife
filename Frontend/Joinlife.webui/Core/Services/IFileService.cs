namespace Joinlife.webui.Core.Services;

public interface IFileService
{
    Task<string> UploadImageAsync(IFormFile photo, string containerName);
}
