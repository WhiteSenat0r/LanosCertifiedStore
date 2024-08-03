using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated;

public sealed class Vehicle : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = null!;
    public double Displacement { get; set; }
    public int Mileage { get; set; }
    public int ProductionYear { get; set; }
    public Guid LocationTownId { get; set; }
    public VehicleLocationTown LocationTown { get; set; } = null!;
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
    public Guid OwnerId { get; set; }
    public User Owner { get; set; } = null!;
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
        Guid ownerId,
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
        OwnerId = ownerId;
        Displacement = displacement;
        Prices.Add(new VehiclePrice(Id, price));
        Description = description;
        ProductionYear = productionYear;
        Mileage = mileage;
    }
}
