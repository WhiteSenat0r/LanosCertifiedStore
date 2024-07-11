using Domain.Entities.VehicleRelated;

namespace Domain.Entities.Common.Classes;

public abstract class NamedVehicleTypeAspect : NamedVehicleAspect
{
    public ICollection<VehicleModel> Models { get; set; } = [];
    public ICollection<Vehicle> Vehicles { get; set; } = [];

    protected NamedVehicleTypeAspect() { }

    protected NamedVehicleTypeAspect(string name) : base(name) { }
}