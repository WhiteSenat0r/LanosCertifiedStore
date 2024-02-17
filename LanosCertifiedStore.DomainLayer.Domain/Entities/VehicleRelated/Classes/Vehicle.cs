using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class Vehicle : IEntity<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public double Displacement { get; init; }
    public string Description { get; init; } = null!;
    public VehicleBrand Brand { get; init; } = null!;
    public VehicleModel Model { get; init; } = null!;
    public VehicleColor Color { get; init; } = null!;
    public VehicleType Type { get; init; } = null!;
    public ICollection<VehicleImage> Images { get; init; } = null!;
    public ICollection<VehiclePrice> Prices { get; init; } = new List<VehiclePrice>();

    public Vehicle() { }
    
    public Vehicle(
        VehicleBrand brand,
        VehicleModel model,
        VehicleColor color,
        VehicleType type,
        decimal price,
        double displacement,
        string description,
        ICollection<VehicleImage> images)
    {
        Prices.Add(new VehiclePrice(this, price));
        Brand = brand;
        Model = model;
        Color = color;
        Type = type;
        Displacement = displacement;
        Description = description;
        Images = images;
    }
}
