using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated;

namespace Application.RequestParameters;

public sealed class VehicleModelFilteringRequestParameters : BaseFilteringRequestParameters<VehicleModel>,
    IVehicleModelFilteringRequestParameters
{
    public string? Name { get; set; }
    public string? ContainedBrandName { get; set; }
    public VehicleModelSelectionProfile SelectionProfile { get; set; } = VehicleModelSelectionProfile.Default;
}