using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Enums.RequestParametersRelated.LocationRelated;

namespace Application.RequestParams.LocationRelated;

public sealed class VehicleLocationAreaFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationArea>,
    IVehicleLocationAreaFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationAreaSelectionProfile SelectionProfile => VehicleLocationAreaSelectionProfile.Default;
}