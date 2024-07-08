using Application.Shared.ResultRelated;
using Microsoft.AspNetCore.Http;

namespace Application.Contracts.ServicesRelated.ImageService;

public interface IImageService
{
    Task<ImageResult> UploadImageAsync(IFormFile imageFile, string desiredPath);
    Task<bool> TryDeletePhotoAsync(string imageId);
    Task<bool> TryRollbackImageUploadAsync();
}