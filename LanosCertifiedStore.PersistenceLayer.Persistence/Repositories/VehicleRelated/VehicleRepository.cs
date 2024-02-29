using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated;

internal class VehicleRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleSelectionProfile, Vehicle, VehicleDataModel>(mapper, dbContext)
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
        var vehicleModelQuery = QueryEvaluator.GetSingleEntityQueryable(
            id, Context.Set<VehicleDataModel>(), new VehicleFilteringRequestParameters
            {
                SelectionProfile = VehicleSelectionProfile.Single
            });

        var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();

        return vehicleModel is not null
            ? Mapper.Map<VehicleDataModel, Vehicle>(vehicleModel)
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryEvaluator.GetRelevantCountQueryable(
            Context.Set<VehicleDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters) =>
        QueryEvaluator.GetAllEntitiesQueryable(
            Context.Set<VehicleDataModel>(), filteringRequestParameters);

    private protected override BaseQueryEvaluator<VehicleSelectionProfile, Vehicle, VehicleDataModel>
        GetQueryEvaluator() =>
        new VehicleQueryEvaluator(new VehicleSelectionProfiles(), new VehicleFilteringCriteria());
}