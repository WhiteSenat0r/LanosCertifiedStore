using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleType : NamedVehicleAspect
{
    // TODO Add vehicle collection property
    public VehicleType() {}
    public VehicleType(string name) : base(name) {}
}
