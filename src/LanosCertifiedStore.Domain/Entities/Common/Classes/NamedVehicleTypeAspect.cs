using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Domain.Entities.Common.Classes;

public abstract class NamedVehicleTypeAspect : NamedAspect
{
    public ICollection<VehicleModel> Models { get; set; } = [];
    public ICollection<Vehicle> Vehicles { get; set; } = [];

    protected NamedVehicleTypeAspect() { }

    protected NamedVehicleTypeAspect(string name) : base(name) { }
}