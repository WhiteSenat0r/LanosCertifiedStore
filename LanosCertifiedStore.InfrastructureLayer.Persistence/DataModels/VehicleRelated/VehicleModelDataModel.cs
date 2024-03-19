using Persistence.DataModels.Common.Classes;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleModelDataModel : NamedVehicleAspect
{
    public Guid VehicleBrandId { get; set; }
    public VehicleBrandDataModel VehicleBrand { get; set; } = null!;
    public ICollection<VehicleTypeDataModel> AvailableTypes { get; set; } = [];
    public ICollection<VehicleEngineTypeDataModel> AvailableEngineTypes { get; set; } = [];
    public ICollection<VehicleTransmissionTypeDataModel> AvailableTransmissionTypes { get; set; } = [];
    public ICollection<VehicleDrivetrainTypeDataModel> AvailableDrivetrainTypes { get; set; } = [];
    public ICollection<VehicleBodyTypeDataModel> AvailableBodyTypes { get; set; } = [];
    public ICollection<VehicleDataModel> Vehicles { get; set; } = [];

    public VehicleModelDataModel() { }

    public VehicleModelDataModel(
        Guid vehicleBrandId,
        string name,
        ICollection<VehicleTypeDataModel> availableTypes) : base(name)
    {
        VehicleBrandId = vehicleBrandId;
        AvailableTypes = availableTypes;
    }
}