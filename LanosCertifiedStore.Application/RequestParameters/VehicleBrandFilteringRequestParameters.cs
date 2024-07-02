using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated;

namespace Application.RequestParameters;

public sealed class VehicleBrandFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBrand>,
    IVehicleBrandFilteringRequestParameters
{
    public string? Name { get; set; }
    public string? ContainedModelName { get; set; }
    public VehicleBrandProjectionProfile ProjectionProfile { get; set; } = VehicleBrandProjectionProfile.Default;
}