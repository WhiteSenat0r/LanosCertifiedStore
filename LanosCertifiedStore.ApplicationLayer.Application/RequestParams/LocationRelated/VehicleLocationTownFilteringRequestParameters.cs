using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;

namespace Application.RequestParams.LocationRelated;

public sealed class VehicleLocationTownFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationTown>,
    IVehicleLocationTownFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationTownSelectionProfile SelectionProfile => VehicleLocationTownSelectionProfile.Default;
}