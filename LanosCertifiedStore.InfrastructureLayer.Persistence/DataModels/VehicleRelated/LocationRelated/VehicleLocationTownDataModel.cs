using Domain.Entities.VehicleRelated.Classes.Common.Classes;

namespace Persistence.DataModels.VehicleRelated.LocationRelated;

public sealed class VehicleLocationTownDataModel : NamedVehicleAspect
{
    public Guid LocationRegionId { get; set; }
    public VehicleLocationRegionDataModel LocationRegion { get; init; } = null!;
    
    public VehicleLocationTownDataModel() { }

    public VehicleLocationTownDataModel(string name) : base(name) { }

    public VehicleLocationTownDataModel(string name, VehicleLocationRegionDataModel locationRegion) : base(name) => 
        LocationRegion = locationRegion;
}