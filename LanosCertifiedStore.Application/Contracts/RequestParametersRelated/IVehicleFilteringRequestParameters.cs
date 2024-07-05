using Application.Contracts.Common;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface IVehicleFilteringRequestParameters : IFilteringRequestParameters<Vehicle>
{
    string? Brand { get; set; }
    string? Model { get; set; }
    string? Type { get; set; }
    string? Color { get; set; }
    decimal? LowerPriceLimit { get; set; }
    decimal? UpperPriceLimit { get; set; }
}