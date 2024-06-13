using Domain.Models.VehicleRelated.Classes.Common.Classes;

namespace Persistence.DataModels.VehicleRelated.LocationRelated;

public sealed class VehicleLocationRegionDataModel : NamedVehicleAspect
{
    public ICollection<VehicleLocationAreaDataModel> RelatedAreas { get; set; } = [];
    public ICollection<VehicleLocationTownDataModel> RelatedTowns { get; set; } = [];
    
    public VehicleLocationRegionDataModel() { }

    public VehicleLocationRegionDataModel(string name) : base(name) { }
}