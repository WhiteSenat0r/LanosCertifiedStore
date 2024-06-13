using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.Common.Classes;
using Domain.Models.VehicleRelated.Classes.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleEngineTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleEngineType>,
    IVehicleEngineTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleEngineTypeSelectionProfile SelectionProfile => VehicleEngineTypeSelectionProfile.Default;
}