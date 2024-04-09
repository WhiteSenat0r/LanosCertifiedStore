using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleType>,
    IVehicleTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleTypeSelectionProfile SelectionProfile { get; } = VehicleTypeSelectionProfile.Default;
}