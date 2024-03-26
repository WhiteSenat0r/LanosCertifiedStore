using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated;
using Persistence.Repositories.VehiclePriceRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehiclePriceRelated;

internal class VehiclePriceRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehiclePriceSelectionProfile,
        VehiclePrice,
        VehiclePriceDataModel,
        IVehiclePriceFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehiclePrice>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null!)
    {
        var vehiclePriceQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehiclePrices = await vehiclePriceQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehiclePriceDataModel>, IReadOnlyList<VehiclePrice>>(vehiclePrices);
    }

    public override async Task<VehiclePrice?> GetEntityByIdAsync(Guid id)
    {
        var vehiclePriceQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehiclePriceDataModel>(), new VehiclePriceFilteringRequestParameters
            {
                SelectionProfile = VehiclePriceSelectionProfile.Full
            });

        var vehiclePrice = await vehiclePriceQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehiclePrice is not null 
            ? Mapper.Map<VehiclePriceDataModel, VehiclePrice>(vehiclePrice) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehiclePriceDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehiclePriceDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehiclePriceDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehiclePriceSelectionProfile,
            VehiclePrice,
            VehiclePriceDataModel,
            IVehiclePriceFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehiclePriceQueryBuilder(new VehiclePriceSelectionProfiles(), new VehiclePriceFilteringCriteria());
}