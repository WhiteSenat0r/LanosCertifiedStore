using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Domain.Models.VehicleRelated.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder.Common;

namespace Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

internal class VehiclePriceSelectionProfiles : 
    BaseSelectionProfiles<VehiclePriceSelectionProfile, VehiclePrice, VehiclePriceDataModel>
{
    private readonly Dictionary<VehiclePriceSelectionProfile,
            Func<IQueryable<VehiclePriceDataModel>, IQueryable<VehiclePriceDataModel>>>
        _mappedProfiles = new()
        {
            { VehiclePriceSelectionProfile.Default, GetDefaultProfileQueryable },
            { VehiclePriceSelectionProfile.Full, GetFullProfileQueryable },
        };

    public override IQueryable<VehiclePriceDataModel> GetSuitableSelectionProfileQueryable(
        IQueryable<VehiclePriceDataModel> inputQueryable,
        IFilteringRequestParameters<VehiclePrice>? requestParameters = null)
    {
        if (requestParameters is null) 
            return _mappedProfiles[VehiclePriceSelectionProfile.Default](inputQueryable);
        
        var brandRequestParams = requestParameters as IVehiclePriceFilteringRequestParameters;

        return _mappedProfiles[brandRequestParams!.SelectionProfile](inputQueryable);
    }

    private static IQueryable<VehiclePriceDataModel> GetDefaultProfileQueryable(
        IQueryable<VehiclePriceDataModel> queryable) =>
        queryable.Select(vehiclePrice => new VehiclePriceDataModel
        {
            Id = vehiclePrice.Id,
            Value = vehiclePrice.Value
        });
    
    private static IQueryable<VehiclePriceDataModel> GetFullProfileQueryable(
        IQueryable<VehiclePriceDataModel> queryable) =>
        queryable.Select(vehiclePrice => new VehiclePriceDataModel
        {
            Id = vehiclePrice.Id,
            Value = vehiclePrice.Value,
            IssueDate = vehiclePrice.IssueDate
        });
}