using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class VehicleModelFilteringRequestParameters : BaseFilteringRequestParameters<VehicleModel>,
    IVehicleModelFilteringRequestParameters
{
    public string? Name { get; set; }
    public string? ContainedBrandName { get; set; }
    public VehicleModelSelectionProfile SelectionProfile { get; set; } = VehicleModelSelectionProfile.Default;
}