using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Application.RequestParams;

public sealed class VehicleBrandFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBrand>,
    IVehicleBrandFilteringRequestParameters
{
    public string? Name { get; set; }
    public string? ContainedModelName { get; set; }
    public VehicleBrandSelectionProfile SelectionProfile { get; set; } = VehicleBrandSelectionProfile.Default;
}