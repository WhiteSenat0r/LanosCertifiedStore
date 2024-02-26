using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleBrandDataModel : NamedVehicleAspect
{
    public ICollection<VehicleModelDataModel> Models { get; set; } = new List<VehicleModelDataModel>();
    public ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();
    
    public VehicleBrandDataModel() { }

    public VehicleBrandDataModel(string name) : base(name) { }
}
