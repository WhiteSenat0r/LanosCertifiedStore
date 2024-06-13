using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParams.Common.Classes;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;

namespace Application.RequestParams.LocationRelated;

public sealed class VehicleLocationTownFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationTown>,
    IVehicleLocationTownFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationTownSelectionProfile SelectionProfile => VehicleLocationTownSelectionProfile.Default;
}