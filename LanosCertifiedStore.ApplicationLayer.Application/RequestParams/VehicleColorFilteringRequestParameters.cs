using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class VehicleColorFilteringRequestParameters : BaseFilteringRequestParameters<VehicleColor>,
    IVehicleColorFilteringRequestParameters
{
    public string? Name { get; set; }
}