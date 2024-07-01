using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated;

public sealed class VehicleBrand : NamedVehicleAspect
{
    public ICollection<VehicleModel> Models { get; set; } = [];
    public ICollection<Vehicle> Vehicles { get; set; } = [];
    
    public VehicleBrand() { }

    public VehicleBrand(string name) : base(name) { }
}
