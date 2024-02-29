using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Application.RequestParams;

public sealed class VehiclePriceFilteringRequestParameters : BaseFilteringRequestParameters<VehiclePrice>,
    IVehiclePriceFilteringRequestParameters
{
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
    public VehiclePriceSelectionProfile SelectionProfile { get; set; } = VehiclePriceSelectionProfile.Default;
}