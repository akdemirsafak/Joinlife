namespace File.API.Models;

public record UploadImageModel(IFormFile file,string containerName);