using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels;

internal sealed class VehicleColorDataModel : NamedVehicleAspect
{
    public ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();
    
    public VehicleColorDataModel() {}
    public VehicleColorDataModel(string name) : base(name) {}
}
