using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated.LocationRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Domain.Entities.VehicleRelated;

public sealed class Vehicle : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = null!;
    public double Displacement { get; set; }
    public int Mileage { get; set; }
    public int ProductionYear { get; set; }
    public Guid LocationTownId { get; set; }
    public VehicleLocationTown LocationTown { get; set; } = null!;
    public Guid LocationAreaId { get; set; }
    public VehicleLocationArea LocationArea { get; set; } = null!;
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegion LocationRegion { get; set; } = null!;
    public Guid BrandId { get; set; }
    public VehicleBrand Brand { get; set; } = null!;
    public Guid ModelId { get; set; }
    public VehicleModel Model { get; set; } = null!;
    public Guid ColorId { get; set; }
    public VehicleColor Color { get; set; } = null!;
    public Guid VehicleTypeId { get; set; }
    public VehicleType VehicleType { get; set; } = null!;
    public Guid BodyTypeId { get; set; }
    public VehicleBodyType BodyType { get; set; } = null!;
    public Guid EngineTypeId { get; set; }
    public VehicleEngineType EngineType { get; set; } = null!;
    public Guid TransmissionTypeId { get; set; }
    public VehicleTransmissionType TransmissionType { get; set; } = null!;
    public Guid DrivetrainTypeId { get; set; }
    public VehicleDrivetrainType DrivetrainType { get; set; } = null!;
    public ICollection<VehicleImage> Images { get; set; } = [];
    public ICollection<VehiclePrice> Prices { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Vehicle() { }
    
    public Vehicle(
        Guid brandId,
        Guid modelId,
        Guid vehicleTypeId,
        Guid drivetrainTypeId,
        Guid engineTypeId,
        Guid bodyTypeId,
        Guid transmissionTypeId,
        Guid colorId,
        Guid locationTownId,
        Guid locationAreaId,
        Guid locationRegionId,
        decimal price,
        double displacement,
        string description,
        int productionYear,
        int mileage)
    {
        BrandId = brandId;
        ModelId = modelId;
        VehicleTypeId = vehicleTypeId;
        DrivetrainTypeId = drivetrainTypeId;
        EngineTypeId = engineTypeId;
        BodyTypeId = bodyTypeId;
        TransmissionTypeId = transmissionTypeId;
        ColorId = colorId;
        LocationTownId = locationTownId;
        LocationAreaId = locationAreaId;
        LocationRegionId = locationRegionId;
        Displacement = displacement;
        Prices.Add(new VehiclePrice(Id, price));
        Description = description;
        ProductionYear = productionYear;
        Mileage = mileage;
    }
}
