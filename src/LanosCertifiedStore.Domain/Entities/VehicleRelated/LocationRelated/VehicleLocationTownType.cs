using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationTownType : NamedAspect
{
    public ICollection<VehicleLocationTown> Towns { get; init; } = [];
    
    public VehicleLocationTownType() { }

    public VehicleLocationTownType(string name) : base(name) { }
}