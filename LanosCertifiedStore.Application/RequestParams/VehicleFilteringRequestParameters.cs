using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams.Common.Classes;
using Application.RequestParams.Common.Enums;
using Domain.Models.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class VehicleFilteringRequestParameters(
    ItemQuantitySelection selectionProfile) : BaseFilteringRequestParameters<Vehicle>(),
    IVehicleFilteringRequestParameters
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
    public VehicleSelectionProfile SelectionProfile { get; set; } = VehicleSelectionProfile.Default;
}