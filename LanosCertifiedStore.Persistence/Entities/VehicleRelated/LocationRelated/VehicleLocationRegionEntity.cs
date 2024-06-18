using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Persistence.Entities.VehicleRelated.LocationRelated;

public sealed class VehicleLocationRegionEntity : NamedVehicleAspect
{
    public ICollection<VehicleLocationAreaEntity> RelatedAreas { get; set; } = [];
    public ICollection<VehicleLocationTownEntity> RelatedTowns { get; set; } = [];
    
    public VehicleLocationRegionEntity() { }

    public VehicleLocationRegionEntity(string name) : base(name) { }
}