using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Application.RequestParameters.TypeRelated;

public sealed class VehicleBodyTypeFilteringRequestParameters : BaseFilteringRequestParameters<VehicleBodyType>,
    IVehicleBodyTypeFilteringRequestParameters
{
    public string? Name { get; set; }
    public VehicleBodyTypeSelectionProfile SelectionProfile => VehicleBodyTypeSelectionProfile.Default;
}