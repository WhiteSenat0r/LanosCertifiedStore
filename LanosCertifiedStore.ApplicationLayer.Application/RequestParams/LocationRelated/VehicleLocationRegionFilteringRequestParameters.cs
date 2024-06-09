using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;

namespace Application.RequestParams.LocationRelated;

public sealed class VehicleLocationRegionFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationRegion>,
    IVehicleLocationRegionFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationRegionSelectionProfile SelectionProfile => VehicleLocationRegionSelectionProfile.Default;
}