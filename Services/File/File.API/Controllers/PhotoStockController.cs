using File.API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLib.BaseController;
using SharedLib.Dtos;

namespace File.API.Controllers;


public class PhotoStockController : CustomBaseController
{

    private readonly IImageService _imageService;

    public PhotoStockController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] IFormFile photo, [FromForm] string containerName)
    {
        var imageLink = await _imageService.UploadImageAsync(photo, containerName);
        return CreateActionResult(AppResponse<string>.Success(imageLink));
    }
}
