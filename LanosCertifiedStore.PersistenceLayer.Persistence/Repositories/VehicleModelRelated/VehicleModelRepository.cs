using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleModelRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleModelRelated;

internal class VehicleModelRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleModel, VehicleModelDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleModel>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null!)
    {
        var vehicleModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleModels = await vehicleModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleModelDataModel>, IReadOnlyList<VehicleModel>>(vehicleModels);
    }

    public override async Task<VehicleModel?> GetEntityByIdAsync(Guid id)
    {
        var vehicleModelQueryEvaluator = GetQueryEvaluator(null);

        var vehicleModelQuery = vehicleModelQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleModel is not null 
            ? Mapper.Map<VehicleModelDataModel, VehicleModel>(vehicleModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null)
    {
        var vehicleModelQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
        
        var countedQueryable = vehicleModelQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleModelDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters)
    {
        var vehicleModelQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        return vehicleModelQueryEvaluator.GetAllEntitiesQueryable();
    }

    private protected override BaseQueryEvaluator<VehicleModel, VehicleModelDataModel> GetQueryEvaluator(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters) =>
        new VehicleModelQueryEvaluator(
            includedAspects: VehicleModelIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleModelDataModel>(),
            vehicleFilteringCriteria: new VehicleModelFilteringCriteria());
}