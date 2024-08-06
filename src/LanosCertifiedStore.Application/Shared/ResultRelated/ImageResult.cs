namespace LanosCertifiedStore.Application.Shared.ResultRelated;

public sealed record ImageResult
{
    public string? ImageId { get; private init; }
    public string? ImageUrl { get; private init; }
    public bool IsUploadedSuccessfully { get; private init; }
    public string? ErrorMessage { get; private init; }

    public ImageResult(string errorMessage)
    {
        IsUploadedSuccessfully = false;
        ErrorMessage = errorMessage;
    }
    
    public ImageResult(bool isSuccess, string imageId, string imageUrl)
    {
        IsUploadedSuccessfully = isSuccess;
        ImageId = imageId;
        ImageUrl = imageUrl;
    }
}