using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.LocationRelated;
using Application.Enums.RequestParametersRelated.LocationRelated;
using Application.RequestParams.LocationRelated;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.LocationRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated.LocationRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated;
using Persistence.Repositories.LocationRelated.LocationRegionRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationRegionRelated;

internal class LocationRegionRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleLocationRegionSelectionProfile,
        VehicleLocationRegion,
        VehicleLocationRegionDataModel,
        IVehicleLocationRegionFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleLocationRegion>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters = null!)
    {
        var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleLocationRegionDataModel>, IReadOnlyList<VehicleLocationRegion>>(
            vehicleTypeModels);
    }

    public override async Task<VehicleLocationRegion?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleLocationRegionDataModel>(), new VehicleLocationRegionFilteringRequestParameters());

        var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleTypeModel is not null 
            ? Mapper.Map<VehicleLocationRegionDataModel, VehicleLocationRegion>(vehicleTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleLocationRegionDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleLocationRegionDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleLocationRegionDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleLocationRegionSelectionProfile,
            VehicleLocationRegion,
            VehicleLocationRegionDataModel,
            IVehicleLocationRegionFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleLocationRegionQueryBuilder(
            new VehicleLocationRegionSelectionProfiles(), new VehicleLocationRegionFilteringCriteria());
}