using LanosCertifiedStore.Application.Images;

namespace LanosCertifiedStore.Application.Vehicles.Dtos;

public sealed record VehicleDto
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
    public IEnumerable<PriceDto>? Prices { get; init; }
    public IEnumerable<ImageDto>? Images { get; init; }
    public DateTime CreatedAt { get; init; }
}