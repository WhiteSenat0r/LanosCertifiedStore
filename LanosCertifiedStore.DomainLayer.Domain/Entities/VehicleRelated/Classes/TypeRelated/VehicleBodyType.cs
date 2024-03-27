using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleBodyType : NamedVehicleTypeAspect
{
    public VehicleBodyType() { }
    
    public VehicleBodyType(string name) : base(name) { }
}
