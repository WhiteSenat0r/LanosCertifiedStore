using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParams.Common.Classes;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;

namespace Application.RequestParams.LocationRelated;

public sealed class VehicleLocationAreaFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationArea>,
    IVehicleLocationAreaFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleLocationAreaSelectionProfile SelectionProfile => VehicleLocationAreaSelectionProfile.Default;
}