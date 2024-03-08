using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes.TypesRelated;

public sealed class VehicleType : NamedVehicleAspect
{
    public ICollection<Vehicle> Vehicles { get; init; } = [];
    
    public VehicleType() {}
    
    public VehicleType(string name) : base(name) {}
}
