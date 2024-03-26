using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleBrandDataModel : NamedVehicleAspect
{
    public ICollection<VehicleModelDataModel> Models { get; set; } = [];
    public ICollection<VehicleDataModel> Vehicles { get; set; } = [];
    
    public VehicleBrandDataModel() { }

    public VehicleBrandDataModel(string name) : base(name) { }
}
