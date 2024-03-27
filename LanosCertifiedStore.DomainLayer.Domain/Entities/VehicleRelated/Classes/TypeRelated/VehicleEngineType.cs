using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypeRelated;

public sealed class VehicleEngineType : NamedVehicleTypeAspect
{
    public VehicleEngineType() { }
    
    public VehicleEngineType(string name) : base(name) { }
}
