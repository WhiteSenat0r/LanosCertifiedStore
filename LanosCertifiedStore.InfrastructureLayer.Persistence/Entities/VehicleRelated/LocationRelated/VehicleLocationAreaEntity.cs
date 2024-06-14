using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Persistence.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationAreaEntity : NamedVehicleAspect
{
    public ICollection<VehicleLocationTownEntity> RelatedTowns { get; set; } = [];
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegionEntity LocationRegion { get; set; } = null!;
    
    public VehicleLocationAreaEntity() { }

    public VehicleLocationAreaEntity(string name) : base(name) { }
    
    public VehicleLocationAreaEntity(string name, VehicleLocationRegionEntity locationRegion) : base(name) => 
        LocationRegion = locationRegion;
}