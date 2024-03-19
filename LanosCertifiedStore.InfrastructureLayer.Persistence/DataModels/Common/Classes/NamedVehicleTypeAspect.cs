using Persistence.DataModels.VehicleRelated;

namespace Persistence.DataModels.Common.Classes;

internal abstract class NamedVehicleTypeAspect : NamedVehicleAspect
{
    public ICollection<VehicleModelDataModel> Models { get; set; } = [];
    public ICollection<VehicleDataModel> Vehicles { get; set; } = [];

    protected NamedVehicleTypeAspect() { }

    protected NamedVehicleTypeAspect(string name) : base(name) { }
}