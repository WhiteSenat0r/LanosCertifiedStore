using Application.Contracts.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated;

namespace Application.RequestParameters;

public sealed class VehicleFilteringRequestParameters : BaseFilteringRequestParameters<Vehicle>,
    IVehicleFilteringRequestParameters
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }
    public decimal? LowerPriceLimit { get; set; }
    public decimal? UpperPriceLimit { get; set; }
}