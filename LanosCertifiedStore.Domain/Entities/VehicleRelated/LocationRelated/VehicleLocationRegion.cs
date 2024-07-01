using Domain.Entities.Common.Classes;

namespace Domain.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationRegion : NamedVehicleAspect
{
    public ICollection<VehicleLocationArea> RelatedAreas { get; set; } = [];
    public ICollection<VehicleLocationTown> RelatedTowns { get; set; } = [];
    
    public VehicleLocationRegion() { }

    public VehicleLocationRegion(string name) : base(name) { }
}