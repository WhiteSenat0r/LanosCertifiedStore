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
using Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleTypeRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleTypeRelated;

internal class VehicleTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleTypeSelectionProfile, VehicleType, VehicleTypeDataModel>(mapper, dbContext)
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
        var vehicleTypeModelQuery = QueryEvaluator.GetSingleEntityQueryable(
            id, Context.Set<VehicleTypeDataModel>(), new VehicleTypeFilteringRequestParameters());

        var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleTypeModel is not null 
            ? Mapper.Map<VehicleTypeDataModel, VehicleType>(vehicleTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryEvaluator.GetRelevantCountQueryable(
            Context.Set<VehicleTypeDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleTypeDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters) =>
        QueryEvaluator.GetAllEntitiesQueryable(
            Context.Set<VehicleTypeDataModel>(), filteringRequestParameters);

    private protected override BaseQueryEvaluator<VehicleTypeSelectionProfile, VehicleType, VehicleTypeDataModel>
        GetQueryEvaluator() =>
        new VehicleTypeQueryEvaluator(new VehicleTypeSelectionProfiles(), new VehicleTypeFilteringCriteria());
}