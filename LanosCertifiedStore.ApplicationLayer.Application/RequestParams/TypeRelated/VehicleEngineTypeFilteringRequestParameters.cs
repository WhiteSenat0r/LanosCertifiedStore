using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleEngineTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleEngineType>,
    IVehicleEngineTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleEngineTypeSelectionProfile SelectionProfile { get; } = VehicleEngineTypeSelectionProfile.Default;
}