using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleEngineType : NamedVehicleTypeAspect
{
    public VehicleEngineType() { }

    public VehicleEngineType(string name) : base(name) { }
}