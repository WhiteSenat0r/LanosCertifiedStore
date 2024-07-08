using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleBodyType : NamedVehicleTypeAspect
{
    public VehicleBodyType() { }

    public VehicleBodyType(string name) : base(name) { }
}