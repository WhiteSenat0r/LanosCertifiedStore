using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleEngineType : NamedVehicleTypeAspect
{
    public VehicleEngineType() { }

    public VehicleEngineType(string name) : base(name) { }
}