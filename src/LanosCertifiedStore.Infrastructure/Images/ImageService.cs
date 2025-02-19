using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LanosCertifiedStore.Application.Images;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using Microsoft.AspNetCore.Http;

namespace LanosCertifiedStore.Infrastructure.Images;

internal class ImageService(ICloudinary cloudinarySource) : IImageService
{
    private readonly ICollection<string> _uploadedImagesIdBuffer = new List<string>();

    public async Task<ImageResult> UploadImageAsync(
        IFormFile imageFile, string desiredPath)
    {
        if (IsInvalidPath(desiredPath))
        {
            return new ImageResult("There is something wrong with your path!");
        }

        await using var fileStream = imageFile.OpenReadStream();

        var uploadResult = await cloudinarySource.UploadAsync(
            GetImageUploadParameters(imageFile, fileStream, desiredPath));

        return GetRelevantImageResult(uploadResult);
    }

    public async Task<bool> TryDeletePhotoAsync(string imageId)
    {
        var deletionResult = await cloudinarySource.DestroyAsync(new DeletionParams(imageId));

        return await Task.FromResult(deletionResult.Result.Equals("ok"));
    }

    public async Task<bool> TryRollbackImageUploadAsync()
    {
        foreach (var id in _uploadedImagesIdBuffer)
        {
            var result = await TryDeletePhotoAsync(id);

            if (!result)
            {
                return result;
            }
        }

        _uploadedImagesIdBuffer.Clear();

        return true;
    }

    private ImageResult GetRelevantImageResult(UploadResult imageUploadResult)
    {
        if (imageUploadResult.Error is not null)
        {
            return InstantiateImageResult(imageUploadResult, false);
        }

        _uploadedImagesIdBuffer.Add(imageUploadResult.PublicId);

        return InstantiateImageResult(imageUploadResult);
    }

    private ImageResult InstantiateImageResult(
        UploadResult imageUploadResult, bool isSuccessful = true)
    {
        return isSuccessful
            ? new ImageResult(isSuccessful, imageUploadResult.PublicId, imageUploadResult.SecureUrl.ToString())
            : new ImageResult(imageUploadResult.Error.Message);
    }

    private ImageUploadParams GetImageUploadParameters(
        IFormFile imageFile, Stream fileStream, string? desiredPath) =>
        new()
        {
            File = new FileDescription(imageFile.FileName, fileStream),
            Folder = desiredPath,
            Transformation = new Transformation().Width(1920).Height(1080).Crop("fill")
        };

    private bool IsInvalidPath(string path) =>
        string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path) || !path.Contains('/');
}