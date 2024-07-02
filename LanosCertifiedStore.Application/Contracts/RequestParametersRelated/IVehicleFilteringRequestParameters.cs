using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
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
    VehicleSelectionProfile SelectionProfile { get; set; }
}