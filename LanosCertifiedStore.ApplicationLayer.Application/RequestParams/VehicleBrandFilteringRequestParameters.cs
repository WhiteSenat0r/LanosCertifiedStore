using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams.Common.Classes;
using Domain.Models.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class VehicleBrandFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBrand>,
    IVehicleBrandFilteringRequestParameters
{
    public string? Name { get; set; }
    public string? ContainedModelName { get; set; }
    public VehicleBrandSelectionProfile SelectionProfile { get; set; } = VehicleBrandSelectionProfile.Default;
}