using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleType : NamedVehicleTypeAspect
{
    public VehicleType() {}
    
    public VehicleType(string name) : base(name) {}
}
