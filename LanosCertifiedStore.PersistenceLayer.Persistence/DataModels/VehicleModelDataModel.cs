using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels;

internal sealed class VehicleModelDataModel : NamedVehicleAspect
{
    public Guid VehicleBrandId { get; set; }
    public VehicleBrandDataModel VehicleBrandDataModel { get; set; } = null!;

    public VehicleModelDataModel() {}
    public VehicleModelDataModel(Guid vehicleBrandId, string name) : base(name) =>
        VehicleBrandId = vehicleBrandId;
}
