using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehiclePriceRelated;

internal class VehiclePriceRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehiclePrice, VehiclePriceDataModel>(mapper, dbContext)
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
        var vehiclePriceQueryEvaluator = GetQueryEvaluator(null);

        var vehiclePriceQuery = vehiclePriceQueryEvaluator.GetSingleEntityQueryable(id);

        var vehiclePrice = await vehiclePriceQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehiclePrice is not null 
            ? Mapper.Map<VehiclePriceDataModel, VehiclePrice>(vehiclePrice) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null)
    {
        var vehiclePriceQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
        
        var countedQueryable = vehiclePriceQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehiclePriceDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters)
    {
        var vehiclePriceQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        return vehiclePriceQueryEvaluator.GetAllEntitiesQueryable();
    }

    private protected override BaseQueryEvaluator<VehiclePrice, VehiclePriceDataModel> GetQueryEvaluator(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters) =>
        new VehiclePriceQueryEvaluator(
            includedAspects: VehiclePriceIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehiclePriceDataModel>(),
            priceFilteringCriteria: new VehiclePriceFilteringCriteria());
}