using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

internal class VehiclePriceSelectionProfiles : 
    BaseSelectionProfiles<VehiclePriceSelectionProfile, VehiclePrice, VehiclePriceEntity>
{
    private readonly Dictionary<VehiclePriceSelectionProfile,
            Func<IQueryable<VehiclePriceEntity>, IQueryable<VehiclePriceEntity>>>
        _mappedProfiles = new()
        {
            { VehiclePriceSelectionProfile.Default, GetDefaultProfileQueryable },
            { VehiclePriceSelectionProfile.Full, GetFullProfileQueryable },
        };

    public override IQueryable<VehiclePriceEntity> GetSuitableSelectionProfileQueryable(
        IQueryable<VehiclePriceEntity> inputQueryable,
        IFilteringRequestParameters<VehiclePrice>? requestParameters = null)
    {
        if (requestParameters is null) 
            return _mappedProfiles[VehiclePriceSelectionProfile.Default](inputQueryable);
        
        var brandRequestParams = requestParameters as IVehiclePriceFilteringRequestParameters;

        return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
    }

    private static IQueryable<VehiclePriceEntity> GetDefaultProfileQueryable(
        IQueryable<VehiclePriceEntity> queryable) =>
        queryable.Select(vehiclePrice => new VehiclePriceEntity
        {
            Id = vehiclePrice.Id,
            Value = vehiclePrice.Value
        });
    
    private static IQueryable<VehiclePriceEntity> GetFullProfileQueryable(
        IQueryable<VehiclePriceEntity> queryable) =>
        queryable.Select(vehiclePrice => new VehiclePriceEntity
        {
            Id = vehiclePrice.Id,
            Value = vehiclePrice.Value,
            IssueDate = vehiclePrice.IssueDate
        });
}