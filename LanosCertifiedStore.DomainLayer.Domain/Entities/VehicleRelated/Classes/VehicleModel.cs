using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleModel : NamedVehicleAspect
{
    public VehicleModel() {}
    public VehicleModel(string name) : base(name) { }
}
