using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels.VehicleRelated;

internal sealed class VehicleTypeDataModel : NamedVehicleAspect
{
    public ICollection<VehicleModelDataModel> Models { get; set; } = new List<VehicleModelDataModel>();
    public ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();
    
    public VehicleTypeDataModel() { }

    public VehicleTypeDataModel(string name) : base(name) { }
}