using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated;

namespace Application.RequestParameters;

public sealed class VehiclePriceFilteringRequestParameters : BaseFilteringRequestParameters<VehiclePrice>,
    IVehiclePriceFilteringRequestParameters
{
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
    public VehiclePriceSelectionProfile SelectionProfile { get; set; } = VehiclePriceSelectionProfile.Default;
}