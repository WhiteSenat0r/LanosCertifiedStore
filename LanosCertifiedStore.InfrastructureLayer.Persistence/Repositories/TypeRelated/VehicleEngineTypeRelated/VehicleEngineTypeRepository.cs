using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.TypeRelated;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated;

internal class VehicleEngineTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleEngineTypeSelectionProfile,
        VehicleEngineType,
        VehicleEngineTypeEntity,
        IVehicleEngineTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleEngineType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters = null!)
    {
        var vehicleEngineTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleEngineTypeModels = await vehicleEngineTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleEngineTypeEntity>, IReadOnlyList<VehicleEngineType>>
            (vehicleEngineTypeModels);
    }

    public override async Task<VehicleEngineType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleEngineTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleEngineTypeEntity>(), new VehicleEngineTypeFilteringRequestParameters());

        var vehicleEngineTypeModel = await vehicleEngineTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleEngineTypeModel is not null 
            ? Mapper.Map<VehicleEngineTypeEntity, VehicleEngineType>(vehicleEngineTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleEngineTypeEntity>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleEngineTypeEntity> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleEngineTypeEntity>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleEngineTypeSelectionProfile,
            VehicleEngineType,
            VehicleEngineTypeEntity,
            IVehicleEngineTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleEngineTypeQueryBuilder(
            new VehicleEngineTypeSelectionProfiles(), new VehicleEngineTypeFilteringCriteria());
}