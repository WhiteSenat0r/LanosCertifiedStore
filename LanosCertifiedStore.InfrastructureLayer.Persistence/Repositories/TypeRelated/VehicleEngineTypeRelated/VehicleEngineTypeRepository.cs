using Application.RequestParams.TypeRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated;

internal class VehicleEngineTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleEngineTypeSelectionProfile,
        VehicleEngineType,
        VehicleEngineTypeDataModel,
        IVehicleEngineTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleEngineType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters = null!)
    {
        var vehicleEngineTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleEngineTypeModels = await vehicleEngineTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleEngineTypeDataModel>, IReadOnlyList<VehicleEngineType>>
            (vehicleEngineTypeModels);
    }

    public override async Task<VehicleEngineType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleEngineTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleEngineTypeDataModel>(), new VehicleEngineTypeFilteringRequestParameters());

        var vehicleEngineTypeModel = await vehicleEngineTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleEngineTypeModel is not null 
            ? Mapper.Map<VehicleEngineTypeDataModel, VehicleEngineType>(vehicleEngineTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleEngineTypeDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleEngineTypeDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleEngineTypeDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleEngineTypeSelectionProfile,
            VehicleEngineType,
            VehicleEngineTypeDataModel,
            IVehicleEngineTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleEngineTypeQueryBuilder(
            new VehicleEngineTypeSelectionProfiles(), new VehicleEngineTypeFilteringCriteria());
}