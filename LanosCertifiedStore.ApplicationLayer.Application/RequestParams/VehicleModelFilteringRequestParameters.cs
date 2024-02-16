using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class VehicleModelFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBrand>,
    IVehicleModelFilteringRequestParameters
{
    public string? Name { get; set; }
    public string? ContainedBrandName { get; set; }
}