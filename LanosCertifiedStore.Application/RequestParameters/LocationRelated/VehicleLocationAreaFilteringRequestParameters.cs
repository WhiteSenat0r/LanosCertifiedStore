using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.RequestParameters.LocationRelated;

public sealed class VehicleLocationAreaFilteringRequestParameters : BaseFilteringRequestParameters<VehicleLocationArea>,
    IVehicleLocationAreaFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationAreaSelectionProfile SelectionProfile => VehicleLocationAreaSelectionProfile.Default;
}