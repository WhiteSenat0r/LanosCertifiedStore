using LanosCertifiedStore.Domain.Entities.Common.Classes;

namespace LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationArea : NamedAspect
{
    public ICollection<VehicleLocationTown> RelatedTowns { get; set; } = [];
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegion LocationRegion { get; set; } = null!;
    
    public VehicleLocationArea() { }

    public VehicleLocationArea(string name) : base(name) { }
    
    public VehicleLocationArea(string name, VehicleLocationRegion locationRegion) : base(name) => 
        LocationRegion = locationRegion;
}