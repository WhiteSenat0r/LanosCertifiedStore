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
                IsValidAspectId(castedParams!.BrandId),
                vehicle => vehicle.BrandId.Equals(castedParams.BrandId!.Value)
            ),
            (
                IsValidAspectId(castedParams.ModelId),
                vehicle => vehicle.ModelId.Equals(castedParams.ModelId!.Value)
            ),
            (
                IsValidAspectId(castedParams.TypeId),
                vehicle => vehicle.VehicleTypeId.Equals(castedParams.TypeId!.Value)
            ),
            (
                IsValidAspectId(castedParams.EngineTypeId),
                vehicle => vehicle.EngineTypeId.Equals(castedParams.EngineTypeId!.Value)
            ),
            (
                IsValidAspectId(castedParams.DrivetrainTypeId),
                vehicle => vehicle.DrivetrainTypeId.Equals(castedParams.DrivetrainTypeId!.Value)
            ),
            (
                IsValidAspectId(castedParams.TransmissionTypeId),
                vehicle => vehicle.TransmissionTypeId.Equals(castedParams.TransmissionTypeId!.Value)
            ),
            (
                IsValidAspectId(castedParams.BodyTypeId),
                vehicle => vehicle.BodyTypeId.Equals(castedParams.BodyTypeId!.Value)
            ),
            (
                IsValidAspectId(castedParams.ColorId),
                vehicle => vehicle.ColorId.Equals(castedParams.ColorId!.Value)
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
            )
        ];
    }

    private bool IsValidAspectId(Guid? checkedId)
    {
        return checkedId.HasValue && !Guid.Empty.Equals(checkedId.Value);
    }
}