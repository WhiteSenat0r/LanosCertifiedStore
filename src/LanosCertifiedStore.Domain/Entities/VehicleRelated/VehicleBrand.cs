using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated;

public sealed class VehicleBrand : NamedAspect
{
    public ICollection<VehicleModel> Models { get; set; } = [];
    public ICollection<Vehicle> Vehicles { get; set; } = [];
    
    public VehicleBrand() { }

    public VehicleBrand(string name) : base(name) { }
}
