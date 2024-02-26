using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleModelDataModel : NamedVehicleAspect
{
    public Guid VehicleBrandId { get; set; }
    public VehicleBrandDataModel VehicleBrand { get; set; } = null!;
    public ICollection<VehicleTypeDataModel> AvailableTypes { get; set; } = new List<VehicleTypeDataModel>();
    public ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();

    public VehicleModelDataModel()
    {
    }

    public VehicleModelDataModel(
        Guid vehicleBrandId,
        string name,
        List<VehicleTypeDataModel> availableTypes) : base(name)
    {
        VehicleBrandId = vehicleBrandId;
        AvailableTypes = availableTypes;
    }
}