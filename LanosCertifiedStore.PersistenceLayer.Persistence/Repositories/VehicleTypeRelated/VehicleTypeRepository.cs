using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleTypeRelated;

internal class VehicleTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleType, VehicleTypeDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null!)
    {
        var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleTypeDataModel>, IReadOnlyList<VehicleType>>(vehicleTypeModels);
    }

    public override async Task<VehicleType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTypeQueryEvaluator = GetQueryEvaluator(null);

        var vehicleTypeModelQuery = vehicleTypeQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleTypeModel is not null 
            ? Mapper.Map<VehicleTypeDataModel, VehicleType>(vehicleTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null)
    {
        var vehicleTypeQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        var countedQueryable = vehicleTypeQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleTypeDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters)
    {
        var vehicleTypeQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        return vehicleTypeQueryEvaluator.GetAllEntitiesQueryable();
    }

    private protected override BaseQueryEvaluator<VehicleType, VehicleTypeDataModel> GetQueryEvaluator(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters) =>
        new VehicleTypeQueryEvaluator(
            includedAspects: VehicleTypeIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleTypeDataModel>(),
            typeFilteringCriteria: new VehicleTypeFilteringCriteria());
}