namespace Application.Images;

public sealed record ImageDto
{
    public Guid Id { get; init; }
    public string? ImageUrl { get; init; }
    public bool IsMainImage { get; init; }
}