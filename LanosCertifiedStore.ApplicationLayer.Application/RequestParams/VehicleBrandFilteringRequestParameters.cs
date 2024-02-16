using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class VehicleBrandFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBrand>,
    IVehicleBrandFilteringRequestParameters
{
    public string? Name { get; set; }
    public string? ContainedModelName { get; set; }
}