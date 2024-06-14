using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParams.LocationRelated;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated;
using Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated;

internal class LocationAreaRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleLocationAreaSelectionProfile,
        VehicleLocationArea,
        VehicleLocationAreaEntity,
        IVehicleLocationAreaFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleLocationArea>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters = null!)
    {
        var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleLocationAreaEntity>, IReadOnlyList<VehicleLocationArea>>(
            vehicleTypeModels);
    }

    public override async Task<VehicleLocationArea?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleLocationAreaEntity>(), new VehicleLocationAreaFilteringRequestParameters());

        var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleTypeModel is not null 
            ? Mapper.Map<VehicleLocationAreaEntity, VehicleLocationArea>(vehicleTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleLocationAreaEntity>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleLocationAreaEntity> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleLocationAreaEntity>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleLocationAreaSelectionProfile,
            VehicleLocationArea,
            VehicleLocationAreaEntity,
            IVehicleLocationAreaFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleLocationAreaQueryBuilder(
            new VehicleLocationAreaSelectionProfiles(), new VehicleLocationAreaFilteringCriteria());
}