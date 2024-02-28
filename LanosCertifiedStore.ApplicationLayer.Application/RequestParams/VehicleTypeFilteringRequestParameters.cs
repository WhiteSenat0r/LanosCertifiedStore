using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Application.RequestParams;

public sealed class VehicleTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleType>,
    IVehicleTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleTypeSelectionProfile SelectionProfile { get; } = VehicleTypeSelectionProfile.Default;
}