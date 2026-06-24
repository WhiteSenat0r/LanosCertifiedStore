using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.SelectorRelated;

internal sealed class VehiclesFilteringCriteriaSelector : QueryFilteringCriteriaSelectorBase<Vehicle>
{
    private protected override IReadOnlyCollection<(bool IsValid, Expression<Func<Vehicle, bool>> Expression)>
        GetAspectMappings(IFilteringRequestParameters<Vehicle> filteringRequestParameters)
    {
        var parameters = (filteringRequestParameters as IVehicleFilteringRequestParameters)!;

        return
        [
            (
                IsValidFilterList(parameters.BrandIds),
                vehicle => parameters.BrandIds!.Contains(vehicle.BrandId)
            ),
            (
                IsValidFilterList(parameters.ModelIds),
                vehicle => parameters.ModelIds!.Contains(vehicle.ModelId)
            ),
            (
                IsValidFilterList(parameters.VehicleTypeIds),
                vehicle => parameters.VehicleTypeIds!.Contains(vehicle.VehicleTypeId)
            ),
            (
                IsValidFilterList(parameters.ColorIds),
                vehicle => parameters.ColorIds!.Contains(vehicle.ColorId)
            ),
            (
                IsValidFilterList(parameters.BodyTypeIds),
                vehicle => parameters.BodyTypeIds!.Contains(vehicle.BodyTypeId)
            ),
            (
                IsValidFilterList(parameters.EngineTypeIds),
                vehicle => parameters.EngineTypeIds!.Contains(vehicle.EngineTypeId)
            ),
            (
                IsValidFilterList(parameters.TransmissionTypeIds),
                vehicle => parameters.TransmissionTypeIds!.Contains(vehicle.TransmissionTypeId)
            ),
            (
                IsValidFilterList(parameters.DrivetrainTypeIds),
                vehicle => parameters.DrivetrainTypeIds!.Contains(vehicle.DrivetrainTypeId)
            ),
            (
                IsValidFilterList(parameters.LocationTownIds),
                vehicle => parameters.LocationTownIds!.Contains(vehicle.LocationTownId)
            ),
            (
                IsValidFilterList(parameters.LocationAreaIds),
                vehicle => parameters.LocationAreaIds!.Contains(vehicle.LocationAreaId)
            ),
            (
                IsValidFilterList(parameters.LocationRegionIds),
                vehicle => parameters.LocationRegionIds!.Contains(vehicle.LocationRegionId)
            ),
            (
                parameters.LowerPriceLimit.HasValue,
                vehicle => vehicle.Prices.Any(p => p.Value >= parameters.LowerPriceLimit!.Value)
            ),
            (
                parameters.UpperPriceLimit.HasValue,
                vehicle => vehicle.Prices.Any(p => p.Value <= parameters.UpperPriceLimit!.Value)
            )
        ];
    }

    private static bool IsValidFilterList(List<Guid>? filterList)
    {
        return filterList is { Count: > 0 };
    }
}
