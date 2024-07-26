using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationRegion : NamedAspect
{
    public ICollection<VehicleLocationArea> RelatedAreas { get; set; } = [];
    public ICollection<VehicleLocationTown> RelatedTowns { get; set; } = [];
    
    public VehicleLocationRegion() { }

    public VehicleLocationRegion(string name) : base(name) { }
}