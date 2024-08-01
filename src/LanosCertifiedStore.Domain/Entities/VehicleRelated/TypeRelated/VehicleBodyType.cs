using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

public sealed class VehicleBodyType : NamedVehicleTypeAspect
{
    public VehicleBodyType() { }

    public VehicleBodyType(string name) : base(name) { }
}