using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;

namespace Domain.Contracts.RequestParametersRelated;

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