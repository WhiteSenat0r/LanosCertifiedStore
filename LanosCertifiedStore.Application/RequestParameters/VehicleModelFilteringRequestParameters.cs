using Application.Contracts.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated;

namespace Application.RequestParameters;

public sealed class VehicleModelFilteringRequestParameters : BaseFilteringRequestParameters<VehicleModel>,
    IVehicleModelFilteringRequestParameters
{
    public string? ContainedBrandName { get; set; }
}