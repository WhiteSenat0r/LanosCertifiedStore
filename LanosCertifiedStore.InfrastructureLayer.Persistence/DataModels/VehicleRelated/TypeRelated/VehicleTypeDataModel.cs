using Persistence.DataModels.Common.Classes;

namespace Persistence.DataModels.VehicleRelated.TypeRelated;

internal sealed class VehicleTypeDataModel : NamedVehicleTypeAspect
{
    public VehicleTypeDataModel() { }

    public VehicleTypeDataModel(string name) : base(name) { }
}