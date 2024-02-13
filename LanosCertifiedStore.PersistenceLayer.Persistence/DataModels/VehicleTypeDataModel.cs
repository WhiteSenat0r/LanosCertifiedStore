using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels;

internal sealed class VehicleTypeDataModel : NamedVehicleAspect
{
    public ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();
    
    public VehicleTypeDataModel() {}
    public VehicleTypeDataModel(string name) : base(name) {}
}