using Domain.Contracts.Common;

namespace Application.Dtos.ImageDtos;

public sealed record ImageDto : IIdentifiable<Guid>
{
    public Guid Id { get; init; }
    public string? CloudImageId { get; init; }
    public string? ImageUrl { get; init; }
    public bool IsMainImage { get; init; }
}