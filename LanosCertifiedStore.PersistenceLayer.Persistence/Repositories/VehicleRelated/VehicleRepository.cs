using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated;

internal class VehicleRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<Vehicle, VehicleDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<Vehicle>> GetAllEntitiesAsync(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!)
    {
        var vehicleModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleModels = await vehicleModelsQuery.AsNoTracking().ToListAsync();

        return Mapper.Map<IReadOnlyList<VehicleDataModel>, IReadOnlyList<Vehicle>>(vehicleModels);
    }

    public override async Task<Vehicle?> GetEntityByIdAsync(Guid id)
    {
        var vehicleQueryEvaluator = GetQueryEvaluator(null);

        var vehicleModelQuery = vehicleQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();

        return vehicleModel is not null
            ? Mapper.Map<VehicleDataModel, Vehicle>(vehicleModel)
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null)
    {
        var vehicleQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        var countedQueryable = vehicleQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters)
    {
        var vehicleQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        return vehicleQueryEvaluator.GetAllEntitiesQueryable();
    }

    private protected override BaseQueryEvaluator<Vehicle, VehicleDataModel> GetQueryEvaluator(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters) =>
        new VehicleQueryEvaluator(
            includedAspects: VehicleIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleDataModel>(),
            vehicleFilteringCriteria: new VehicleFilteringCriteria());
}