using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.Common.Classes;
using Domain.Models.VehicleRelated.Classes.TypeRelated;

namespace Application.RequestParams.TypeRelated;

public sealed class VehicleTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleType>,
    IVehicleTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleTypeSelectionProfile SelectionProfile => VehicleTypeSelectionProfile.Default;
}