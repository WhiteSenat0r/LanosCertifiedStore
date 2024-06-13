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
using Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated;
using Persistence.Repositories.LocationRelated.LocationTownRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.LocationRelated.LocationTownRelated;

internal class LocationTownRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleLocationTownSelectionProfile,
        VehicleLocationTown,
        VehicleLocationTownDataModel,
        IVehicleLocationTownFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleLocationTown>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters = null!)
    {
        var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleLocationTownDataModel>, IReadOnlyList<VehicleLocationTown>>(
            vehicleTypeModels);
    }

    public override async Task<VehicleLocationTown?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleLocationTownDataModel>(), new VehicleLocationTownFilteringRequestParameters());

        var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleTypeModel is not null 
            ? Mapper.Map<VehicleLocationTownDataModel, VehicleLocationTown>(vehicleTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleLocationTownDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleLocationTownDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleLocationTownDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleLocationTownSelectionProfile,
            VehicleLocationTown,
            VehicleLocationTownDataModel,
            IVehicleLocationTownFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleLocationTownQueryBuilder(
            new VehicleLocationTownSelectionProfiles(), new VehicleLocationTownFilteringCriteria());
}