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
using Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated;

internal class VehicleTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleTypeSelectionProfile,
        VehicleType,
        VehicleTypeEntity,
        IVehicleTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null!)
    {
        var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleTypeEntity>, IReadOnlyList<VehicleType>>(vehicleTypeModels);
    }

    public override async Task<VehicleType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleTypeEntity>(), new VehicleTypeFilteringRequestParameters());

        var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleTypeModel is not null 
            ? Mapper.Map<VehicleTypeEntity, VehicleType>(vehicleTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleTypeEntity>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleTypeEntity> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleTypeEntity>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleTypeSelectionProfile,
            VehicleType,
            VehicleTypeEntity,
            IVehicleTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleTypeQueryBuilder(new VehicleTypeSelectionProfiles(), new VehicleTypeFilteringCriteria());
}