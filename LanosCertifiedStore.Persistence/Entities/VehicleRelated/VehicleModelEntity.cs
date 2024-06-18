using Persistence.Entities.Common.Classes;
using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.Entities.VehicleRelated;

internal sealed class VehicleModelEntity : NamedVehicleAspect
{
    public int MinimalProductionYear { get; set; }
    public int? MaximumProductionYear { get; set; }
    public Guid VehicleBrandId { get; set; }
    public VehicleBrandEntity VehicleBrand { get; set; } = null!;
    public Guid VehicleTypeId { get; set; }
    public VehicleTypeEntity VehicleType { get; set; } = null!;
    public ICollection<VehicleEngineTypeEntity> AvailableEngineTypes { get; set; } = [];
    public ICollection<VehicleTransmissionTypeEntity> AvailableTransmissionTypes { get; set; } = [];
    public ICollection<VehicleDrivetrainTypeEntity> AvailableDrivetrainTypes { get; set; } = [];
    public ICollection<VehicleBodyTypeEntity> AvailableBodyTypes { get; set; } = [];
    public ICollection<VehicleEntity> Vehicles { get; set; } = [];

    public VehicleModelEntity() { }

    public VehicleModelEntity(
        Guid vehicleBrandId,
        Guid vehicleTypeId,
        string name,
        ICollection<VehicleEngineTypeEntity> availableEngineTypes,
        ICollection<VehicleTransmissionTypeEntity> availableTransmissionTypes,
        ICollection<VehicleDrivetrainTypeEntity> availableDrivetrainTypes,
        ICollection<VehicleBodyTypeEntity> availableBodyTypes,
        int minimalProductionYear,
        int? maximumProductionYear = null) : base(name)
    {
        VehicleBrandId = vehicleBrandId;
        VehicleTypeId = vehicleTypeId;
        MinimalProductionYear = minimalProductionYear;
        MaximumProductionYear = maximumProductionYear;
        AvailableEngineTypes = availableEngineTypes;
        AvailableTransmissionTypes = availableTransmissionTypes;
        AvailableDrivetrainTypes = availableDrivetrainTypes;
        AvailableBodyTypes = availableBodyTypes;
    }
}