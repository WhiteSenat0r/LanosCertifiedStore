using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Domain.Models.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleType : NamedVehicleTypeAspect
{
    public VehicleType() {}
    
    public VehicleType(string name) : base(name) {}
}
