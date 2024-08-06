namespace LanosCertifiedStore.Application.Images;

public sealed record ImageDto
{
    public string CloudImageId { get; init; }
    public string? ImageUrl { get; init; }
    public bool IsMainImage { get; init; }
}