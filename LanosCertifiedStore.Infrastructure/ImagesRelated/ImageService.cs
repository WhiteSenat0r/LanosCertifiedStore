using Application.Contracts.ServicesRelated.ImageService;
using Application.Core.Results;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LanosCertifiedStore.InfrastructureLayer.Services.ImagesRelated.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.InfrastructureLayer.Services.ImagesRelated;

internal class ImageService : IImageService
{
    private readonly ICloudinary _cloudinarySource;
    private readonly ICollection<string> _uploadedImagesIdBuffer = new List<string>();

    public ImageService(IOptions<CloudinarySettings> cloudinaryOptions) =>
        _cloudinarySource = InstantiateCloudinarySource(cloudinaryOptions);

    public async Task<ImageResult> UploadImageAsync(
        IFormFile imageFile, string desiredPath)
    {
        if (IsInvalidPath(desiredPath))
            return new ImageResult("There is something wrong with your path!");

        await using var fileStream = imageFile.OpenReadStream();

        var uploadResult = await _cloudinarySource.UploadAsync(
            GeImageUploadParameters(imageFile, fileStream, desiredPath));

        return GetRelevantImageResult(uploadResult);
    }

    public async Task<bool> TryDeletePhotoAsync(string imageId)
    {
        var deletionResult = await _cloudinarySource.DestroyAsync(new DeletionParams(imageId));

        return await Task.FromResult(deletionResult.Result.Equals("ok"));
    }

    public async Task<bool> TryRollbackImageUploadAsync()
    {
        foreach (var id in _uploadedImagesIdBuffer)
        {
            var result = await TryDeletePhotoAsync(id);

            if (!result) return result;
        }

        _uploadedImagesIdBuffer.Clear();

        return true;
    }

    private ImageResult GetRelevantImageResult(UploadResult imageUploadResult)
    {
        if (imageUploadResult.Error is not null)
            return InstantiateImageResult(imageUploadResult, false);

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

    private ImageUploadParams GeImageUploadParameters(
        IFormFile imageFile, Stream fileStream, string? desiredPath) =>
        new()
        {
            File = new FileDescription(imageFile.FileName, fileStream),
            Folder = desiredPath,
            Transformation = new Transformation().Width(1920).Height(1080).Crop("fill")
        };

    private ICloudinary InstantiateCloudinarySource(IOptions<CloudinarySettings> cloudinaryOptions)
    {
        var cloudinaryAccount = new Account(
            cloudinaryOptions.Value.CloudName,
            cloudinaryOptions.Value.ApiKey,
            cloudinaryOptions.Value.ApiSecret
        );

        return new Cloudinary(cloudinaryAccount);
    }

    private bool IsInvalidPath(string path) =>
        string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path) || !path.Contains('/');
}