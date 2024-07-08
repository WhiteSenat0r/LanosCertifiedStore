using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleType : NamedVehicleTypeAspect
{
    public VehicleType() { }

    public VehicleType(string name) : base(name) { }
}