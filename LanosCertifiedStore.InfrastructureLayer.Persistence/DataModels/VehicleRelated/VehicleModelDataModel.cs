using Persistence.DataModels.Common.Classes;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleModelDataModel : NamedVehicleAspect
{
    public int MinimalProductionYear { get; set; }
    public int? MaximumProductionYear { get; set; }
    public Guid VehicleBrandId { get; set; }
    public VehicleBrandDataModel VehicleBrand { get; set; } = null!;
    public Guid VehicleTypeId { get; set; }
    public VehicleTypeDataModel VehicleType { get; set; } = null!;
    public ICollection<VehicleEngineTypeDataModel> AvailableEngineTypes { get; set; } = [];
    public ICollection<VehicleTransmissionTypeDataModel> AvailableTransmissionTypes { get; set; } = [];
    public ICollection<VehicleDrivetrainTypeDataModel> AvailableDrivetrainTypes { get; set; } = [];
    public ICollection<VehicleBodyTypeDataModel> AvailableBodyTypes { get; set; } = [];
    public ICollection<VehicleDataModel> Vehicles { get; set; } = [];

    public VehicleModelDataModel() { }

    public VehicleModelDataModel(
        Guid vehicleBrandId,
        Guid vehicleTypeId,
        string name,
        ICollection<VehicleEngineTypeDataModel> availableEngineTypes,
        ICollection<VehicleTransmissionTypeDataModel> availableTransmissionTypes,
        ICollection<VehicleDrivetrainTypeDataModel> availableDrivetrainTypes,
        ICollection<VehicleBodyTypeDataModel> availableBodyTypes,
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