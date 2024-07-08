using Application.Shared.RequestParamsRelated;
using Domain.Entities.VehicleRelated;

namespace Application.Vehicles;

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