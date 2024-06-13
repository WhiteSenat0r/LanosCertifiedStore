using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Domain.Models.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleBodyType : NamedVehicleTypeAspect
{
    public VehicleBodyType() { }
    
    public VehicleBodyType(string name) : base(name) { }
}
