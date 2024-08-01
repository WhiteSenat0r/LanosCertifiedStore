using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleType : NamedVehicleTypeAspect
{
    public VehicleType() { }

    public VehicleType(string name) : base(name) { }
}