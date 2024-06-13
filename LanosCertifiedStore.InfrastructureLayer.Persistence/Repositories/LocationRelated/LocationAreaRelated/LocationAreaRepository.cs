using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParams.LocationRelated;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated;
using Persistence.Repositories.LocationRelated.LocationAreaRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationAreaRelated;

internal class LocationAreaRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleLocationAreaSelectionProfile,
        VehicleLocationArea,
        VehicleLocationAreaDataModel,
        IVehicleLocationAreaFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleLocationArea>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters = null!)
    {
        var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleLocationAreaDataModel>, IReadOnlyList<VehicleLocationArea>>(
            vehicleTypeModels);
    }

    public override async Task<VehicleLocationArea?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleLocationAreaDataModel>(), new VehicleLocationAreaFilteringRequestParameters());

        var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleTypeModel is not null 
            ? Mapper.Map<VehicleLocationAreaDataModel, VehicleLocationArea>(vehicleTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleLocationAreaDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleLocationAreaDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleLocationAreaDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleLocationAreaSelectionProfile,
            VehicleLocationArea,
            VehicleLocationAreaDataModel,
            IVehicleLocationAreaFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleLocationAreaQueryBuilder(
            new VehicleLocationAreaSelectionProfiles(), new VehicleLocationAreaFilteringCriteria());
}