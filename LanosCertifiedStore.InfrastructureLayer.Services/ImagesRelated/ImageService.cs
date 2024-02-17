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
        IFormFile imageFile, string? desiredPath = null)
    {
        if (IsEmptyFile(imageFile) || IsNotImageFile(imageFile))
            return new ImageResult
            {
                IsUploadedSuccessfully = false
            };

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
        UploadResult imageUploadResult, bool isSuccessful = true) =>
        new()
        {
            ImageId = imageUploadResult.PublicId,
            ImageUrl = imageUploadResult.SecureUrl.ToString(),
            IsUploadedSuccessfully = isSuccessful
        };

    private ImageUploadParams GeImageUploadParameters(
        IFormFile imageFile, Stream fileStream, string? desiredPath) =>
        string.IsNullOrEmpty(desiredPath) || string.IsNullOrWhiteSpace(desiredPath)
            ? new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, fileStream),
                Transformation = new Transformation().Width(1920).Height(1080).Crop("fill")
            }
            : new ImageUploadParams
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
    
    private bool IsEmptyFile(IFormFile imageFile) => 
        imageFile.Length.Equals(0);

    private bool IsNotImageFile(IFormFile imageFile) =>
        !string.Equals(imageFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
        !string.Equals(imageFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
        !string.Equals(imageFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase);
}