namespace Application.Dtos.VehicleDtos;

public sealed record ActionVehicleDto
{
    public Guid Id { get; init; }
    public string Description { get; init; } = null!;
    public Guid BrandId { get; init; }
    public Guid ModelId { get; init; }
    public Guid ColorId { get; init; }
    public Guid TypeId { get; init; }
    public Guid DisplacementId { get; init; }
    public decimal Price { get; init; }
}