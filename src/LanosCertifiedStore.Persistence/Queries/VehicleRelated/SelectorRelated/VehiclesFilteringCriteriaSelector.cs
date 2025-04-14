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
        var castedParams = filteringRequestParameters as IVehicleFilteringRequestParameters;

        return
        [
            (
                castedParams!.BrandIds.Any(),
                vehicle => castedParams.BrandIds.Contains(vehicle.BrandId)
            ),
            (
                castedParams.ModelIds.Any(),
                vehicle => castedParams.ModelIds.Contains(vehicle.ModelId)
            ),
            (
                castedParams.TypeIds.Any(),
                vehicle => castedParams.TypeIds.Contains(vehicle.VehicleTypeId)
            ),
            (
                castedParams.EngineTypeIds.Any(),
                vehicle => castedParams.EngineTypeIds.Contains(vehicle.EngineTypeId)
            ),
            (
                castedParams.DrivetrainTypeIds.Any(),
                vehicle => castedParams.DrivetrainTypeIds.Contains(vehicle.DrivetrainTypeId)
            ),
            (
                castedParams.TransmissionTypeIds.Any(),
                vehicle => castedParams.TransmissionTypeIds.Contains(vehicle.TransmissionTypeId)
            ),
            (
                castedParams.BodyTypeIds.Any(),
                vehicle => castedParams.BodyTypeIds.Contains(vehicle.BodyTypeId)
            ),
            (
                castedParams.ColorIds.Any(),
                vehicle => castedParams.ColorIds.Contains(vehicle.ColorId)
            ),
            (
                IsValidAspectId(castedParams.LocationTownId),
                vehicle => vehicle.LocationTownId.Equals(castedParams.LocationTownId!.Value)
            ),
            (
                IsValidAspectId(castedParams.OwnerId),
                vehicle => vehicle.OwnerId.Equals(castedParams.OwnerId!.Value)
            ),
            (
                castedParams.LowerPriceLimit.HasValue,
                vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).First().Value >=
                           castedParams.LowerPriceLimit!.Value
            ),
            (
                castedParams.UpperPriceLimit.HasValue,
                vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).First().Value <=
                           castedParams.UpperPriceLimit!.Value
            ),
            (
                castedParams.ProductionYear.HasValue,
                vehicle => vehicle.ProductionYear == castedParams.ProductionYear
            )
        ];
    }

    private bool IsValidAspectId(Guid? checkedId)
    {
        return checkedId.HasValue && !Guid.Empty.Equals(checkedId.Value);
    }
}