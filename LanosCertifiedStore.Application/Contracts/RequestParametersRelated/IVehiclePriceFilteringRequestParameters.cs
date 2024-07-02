using Application.Contracts.RepositoryRelated.Common;
using Application.Enums.RequestParametersRelated;
using Domain.Entities.VehicleRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface IVehiclePriceFilteringRequestParameters : IFilteringRequestParameters<VehiclePrice>
{
    decimal? LowerPriceLimit { get; set; }
    decimal? UpperPriceLimit { get; set; }
    VehiclePriceSelectionProfile SelectionProfile { get; set; }
}