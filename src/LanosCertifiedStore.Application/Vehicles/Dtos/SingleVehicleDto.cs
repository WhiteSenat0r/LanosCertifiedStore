using LanosCertifiedStore.Application.Images;
using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Application.Vehicles.Dtos;

public sealed record SingleVehicleDto : IIdentifiable<Guid>
{
    public Guid Id { get; init; }
    public string? Description { get; init; }
    public string? Brand { get; init; }
    public string? Model { get; init; }
    public string? Color { get; init; }
    public string? Type { get; init; }
    public string? BodyType { get; init; }
    public string? EngineType { get; init; }
    public string? TransmissionType { get; init; }
    public string? DrivetrainType { get; init; }
    public string? Region { get; init; }
    public string? Area { get; init; }
    public string? Town { get; init; }
    public int? Mileage { get; init; }
    public int? ProductionYear { get; init; }
    public double? Displacement { get; init; }
    public Guid OwnerId { get; init; }
    public OwnerDto OwnerData { get; set; } = default!;
    public IEnumerable<PriceDto>? Prices { get; init; }
    public IEnumerable<ImageDto>? Images { get; init; }
    public DateTime CreatedAt { get; init; }
}