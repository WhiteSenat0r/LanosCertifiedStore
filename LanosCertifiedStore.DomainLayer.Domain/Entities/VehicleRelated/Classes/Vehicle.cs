using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.TypesRelated;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class Vehicle : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public double Displacement { get; init; }
    public int Mileage { get; init; }
    public int ProductionYear { get; init; }
    public string Description { get; init; } = null!;
    public VehicleLocationTown LocationTown { get; init; } = null!;
    public VehicleLocationRegion LocationRegion { get; init; } = null!;
    public VehicleBrand Brand { get; init; } = null!;
    public VehicleModel Model { get; init; } = null!;
    public VehicleColor Color { get; init; } = null!;
    public VehicleType VehicleType { get; init; } = null!;
    public VehicleBodyType BodyType { get; init; } = null!;
    public VehicleEngineType EngineType { get; init; } = null!;
    public VehicleTransmissionType TransmissionType { get; init; } = null!;
    public VehicleDrivetrainType DrivetrainType { get; init; } = null!;
    public ICollection<VehicleImage> Images { get; init; } = new List<VehicleImage>();
    public ICollection<VehiclePrice> Prices { get; init; } = new List<VehiclePrice>();

    public Vehicle() { }
    
    public Vehicle(
        VehicleBrand brand,
        VehicleModel model,
        VehicleColor color,
        VehicleType vehicleType,
        VehicleBodyType bodyType,
        VehicleEngineType engineType,
        VehicleTransmissionType transmissionType,
        VehicleDrivetrainType drivetrainType,
        VehicleLocationTown locationTown,
        VehicleLocationRegion locationRegion,
        decimal price,
        double displacement,
        string description,
        int productionYear,
        int mileage)
    {
        Prices.Add(new VehiclePrice(this, price));
        Brand = brand;
        Model = model;
        Color = color;
        VehicleType = vehicleType;
        BodyType = bodyType;
        EngineType = engineType;
        TransmissionType = transmissionType;
        DrivetrainType = drivetrainType;
        LocationTown = locationTown;
        LocationRegion = locationRegion;
        Displacement = displacement;
        Description = description;
        ProductionYear = productionYear;
        Mileage = mileage;
    }
}
