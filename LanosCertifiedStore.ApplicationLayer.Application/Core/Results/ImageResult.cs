namespace Application.Core.Results;

public record ImageResult
{
    public string? ImageId { get; init; }
    public string? ImageUrl { get; init; }
    public bool IsUploadedSuccessfully { get; init; }
}