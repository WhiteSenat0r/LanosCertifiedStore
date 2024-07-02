using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.RequestParameters.LocationRelated;

public sealed class VehicleLocationTownFilteringRequestParameters : BaseFilteringRequestParameters<VehicleLocationTown>,
    IVehicleLocationTownFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationTownSelectionProfile SelectionProfile => VehicleLocationTownSelectionProfile.Default;
}