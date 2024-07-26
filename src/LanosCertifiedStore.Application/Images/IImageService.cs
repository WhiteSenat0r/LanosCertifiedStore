using LanosCertifiedStore.Application.Shared.ResultRelated;
using Microsoft.AspNetCore.Http;

namespace LanosCertifiedStore.Application.Images;

public interface IImageService
{
    Task<ImageResult> UploadImageAsync(IFormFile imageFile, string desiredPath);
    Task<bool> TryDeletePhotoAsync(string imageId);
    Task<bool> TryRollbackImageUploadAsync();
}