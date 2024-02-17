using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleColorRelated;

internal class VehicleColorRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleColor, VehicleColorDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleColor>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null!)
    {
        var vehicleColorsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleColors = await vehicleColorsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleColorDataModel>, IReadOnlyList<VehicleColor>>(vehicleColors);
    }

    public override async Task<VehicleColor?> GetEntityByIdAsync(Guid id)
    {
        var vehicleColorQueryEvaluator = GetQueryEvaluator(null);

        var vehicleColorQuery = vehicleColorQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleBrandModel = await vehicleColorQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleBrandModel is not null 
            ? Mapper.Map<VehicleColorDataModel, VehicleColor>(vehicleBrandModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null)
    {
        var vehicleColorQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
        
        var countedQueryable = vehicleColorQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleColorDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters)
    {
        var vehicleColorQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        return vehicleColorQueryEvaluator.GetAllEntitiesQueryable();
    }

    private protected override BaseQueryEvaluator<VehicleColor, VehicleColorDataModel> GetQueryEvaluator(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters) =>
        new VehicleColorQueryEvaluator(
            includedAspects: VehicleColorIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleColorDataModel>(),
            colorFilteringCriteria: new VehicleColorFilteringCriteria());
}