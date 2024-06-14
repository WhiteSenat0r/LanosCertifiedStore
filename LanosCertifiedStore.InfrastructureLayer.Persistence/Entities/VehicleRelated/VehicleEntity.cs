using Domain.Contracts.Common;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Entities.VehicleRelated;

internal sealed class VehicleEntity : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = null!;
    public double Displacement { get; set; }
    public int Mileage { get; set; }
    public int ProductionYear { get; set; }
    public Guid LocationTownId { get; set; }
    public VehicleLocationTownEntity LocationTown { get; set; } = null!;
    public Guid LocationAreaId { get; set; }
    public VehicleLocationAreaEntity LocationArea { get; set; } = null!;
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegionEntity LocationRegion { get; set; } = null!;
    public Guid BrandId { get; set; }
    public VehicleBrandEntity Brand { get; set; } = null!;
    public Guid ModelId { get; set; }
    public VehicleModelEntity Model { get; set; } = null!;
    public Guid ColorId { get; set; }
    public VehicleColorEntity Color { get; set; } = null!;
    public Guid VehicleTypeId { get; set; }
    public VehicleTypeEntity VehicleType { get; set; } = null!;
    public Guid BodyTypeId { get; set; }
    public VehicleBodyTypeEntity BodyType { get; set; } = null!;
    public Guid EngineTypeId { get; set; }
    public VehicleEngineTypeEntity EngineType { get; set; } = null!;
    public Guid TransmissionTypeId { get; set; }
    public VehicleTransmissionTypeEntity TransmissionType { get; set; } = null!;
    public Guid DrivetrainTypeId { get; set; }
    public VehicleDrivetrainTypeEntity DrivetrainType { get; set; } = null!;
    public ICollection<VehicleImageEntity> Images { get; set; } = new List<VehicleImageEntity>();
    public ICollection<VehiclePriceEntity> Prices { get; set; } = new List<VehiclePriceEntity>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public VehicleEntity() { }
    
    public VehicleEntity(
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
        Prices.Add(new VehiclePriceEntity(Id, price));
        Description = description;
        ProductionYear = productionYear;
        Mileage = mileage;
    }
}
