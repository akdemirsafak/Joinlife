using Azure.Storage.Blobs;
using File.API.Models;

namespace File.API.Services;

public class ImageService : IImageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public ImageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<bool> DeleteImageAsync(string fileName, string containerName)
    {
        var blobContainter=_blobServiceClient.GetBlobContainerClient(containerName);
        BlobClient file = blobContainter.GetBlobClient(fileName);
        await file.DeleteIfExistsAsync();
        return true;
    }

    public async Task<string> UploadImageAsync(IFormFile file, string containerName)
    {
        // Get the Blob container
        BlobContainerClient containerClient =  _blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

        // Create a unique name for the blob
        string blobName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        // Get a reference to a blob
        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        // Upload image to Azure Blob Storage
        using (Stream stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, true);
        }

        // Return the URL of the uploaded image
        return blobClient.Uri.ToString();
    }
}
