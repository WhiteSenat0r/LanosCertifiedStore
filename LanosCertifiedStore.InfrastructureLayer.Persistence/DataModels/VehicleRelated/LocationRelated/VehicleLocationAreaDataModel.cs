using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Persistence.DataModels.VehicleRelated.LocationRelated;

public sealed class VehicleLocationAreaDataModel : NamedVehicleAspect
{
    public ICollection<VehicleLocationTownDataModel> RelatedTowns { get; set; } = [];
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegionDataModel LocationRegion { get; set; } = null!;
    
    public VehicleLocationAreaDataModel() { }

    public VehicleLocationAreaDataModel(string name) : base(name) { }
    
    public VehicleLocationAreaDataModel(string name, VehicleLocationRegionDataModel locationRegion) : base(name) => 
        LocationRegion = locationRegion;
}