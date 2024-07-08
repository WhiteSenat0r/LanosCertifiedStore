using Domain.Entities.Common.Classes;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Domain.Entities.VehicleRelated;

public sealed class VehicleModel : NamedVehicleAspect
{
    public int MinimalProductionYear { get; set; }
    public int? MaximumProductionYear { get; set; }
    public Guid VehicleBrandId { get; set; }
    public VehicleBrand VehicleBrand { get; set; } = null!;
    public Guid VehicleTypeId { get; set; }
    public VehicleType VehicleType { get; set; } = null!;
    public ICollection<VehicleEngineType> AvailableEngineTypes { get; set; } = [];
    public ICollection<VehicleTransmissionType> AvailableTransmissionTypes { get; set; } = [];
    public ICollection<VehicleDrivetrainType> AvailableDrivetrainTypes { get; set; } = [];
    public ICollection<VehicleBodyType> AvailableBodyTypes { get; set; } = [];
    public ICollection<Vehicle> Vehicles { get; set; } = [];

    public VehicleModel() { }

    public VehicleModel(
        Guid vehicleBrandId,
        Guid vehicleTypeId,
        string name,
        ICollection<VehicleEngineType> availableEngineTypes,
        ICollection<VehicleTransmissionType> availableTransmissionTypes,
        ICollection<VehicleDrivetrainType> availableDrivetrainTypes,
        ICollection<VehicleBodyType> availableBodyTypes,
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