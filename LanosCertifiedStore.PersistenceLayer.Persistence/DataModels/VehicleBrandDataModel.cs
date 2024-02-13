using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels;

internal sealed class VehicleBrandDataModel : NamedVehicleAspect
{
    public ICollection<VehicleModelDataModel> Models { get; set; } = new List<VehicleModelDataModel>();
    
    public VehicleBrandDataModel() {}
    public VehicleBrandDataModel(string name) : base(name) {}
}
