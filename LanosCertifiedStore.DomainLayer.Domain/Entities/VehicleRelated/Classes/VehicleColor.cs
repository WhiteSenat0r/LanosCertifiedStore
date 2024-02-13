using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class VehicleColor : NamedVehicleAspect
{
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    
    public VehicleColor() {}
    
    public VehicleColor(string name) : base(name) {}
}
