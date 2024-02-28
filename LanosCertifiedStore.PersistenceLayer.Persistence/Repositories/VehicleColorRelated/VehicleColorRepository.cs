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
using Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleColorRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleColorRelated;

internal class VehicleColorRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleColorSelectionProfile, VehicleColor, VehicleColorDataModel>(mapper, dbContext)
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
        var vehicleColorQuery = QueryEvaluator.GetSingleEntityQueryable(
            id, Context.Set<VehicleColorDataModel>(), new VehicleColorFilteringRequestParameters());

        var vehicleColorModel = await vehicleColorQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleColorModel is not null 
            ? Mapper.Map<VehicleColorDataModel, VehicleColor>(vehicleColorModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryEvaluator.GetRelevantCountQueryable(
            Context.Set<VehicleColorDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleColorDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters) =>
        QueryEvaluator.GetAllEntitiesQueryable(
            Context.Set<VehicleColorDataModel>(), filteringRequestParameters);

    private protected override BaseQueryEvaluator<VehicleColorSelectionProfile, VehicleColor, VehicleColorDataModel>
        GetQueryEvaluator() =>
        new VehicleColorQueryEvaluator(
            new VehicleColorSelectionProfiles(),
            new VehicleColorFilteringCriteria());
}