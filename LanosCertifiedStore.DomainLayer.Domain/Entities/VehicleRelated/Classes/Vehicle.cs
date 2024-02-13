using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class Vehicle : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; init; } = null!;
    public Guid BrandId { get; init; }
    public VehicleBrand Brand { get; init; } = null!;
    public Guid ModelId { get; init; }
    public VehicleModel Model { get; init; } = null!;
    public Guid ColorId { get; init; }
    public VehicleColor Color { get; init; } = null!;
    public Guid TypeId { get; init; }
    public VehicleType Type { get; init; } = null!;
    public Guid DisplacementId { get; init; }
    public VehicleDisplacement Displacement { get; init; } = null!;
    public ICollection<VehiclePrice> Prices { get; init; } = new List<VehiclePrice>();

    public Vehicle() { }
    public Vehicle(
        Guid brandId,
        Guid modelId,
        Guid typeId,
        Guid colorId,
        Guid displacementId,
        decimal price,
        string description)
    {
        BrandId = brandId;
        ModelId = modelId;
        TypeId = typeId;
        ColorId = colorId;
        DisplacementId = displacementId;
        Prices.Add(new VehiclePrice(Id, price));
        Description = description;
    }
}
