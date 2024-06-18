using Persistence.Entities.Common.Classes;

namespace Persistence.Entities.VehicleRelated.TypeRelated;

internal sealed class VehicleEngineTypeEntity : NamedVehicleTypeAspect
{
    public VehicleEngineTypeEntity() { }

    public VehicleEngineTypeEntity(string name) : base(name) { }
}