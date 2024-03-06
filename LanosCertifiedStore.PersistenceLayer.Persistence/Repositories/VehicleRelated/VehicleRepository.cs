using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RepositoryRelated.VehicleRepositoryRelated;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleRelated.QueryBuilderRelated;
using Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated;

internal class VehicleRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleSelectionProfile,
        Vehicle,
        VehicleDataModel, 
        IVehicleFilteringRequestParameters>(mapper, dbContext),
        IVehicleRepositoryExtensions
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
        var vehicleModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleDataModel>(), new VehicleFilteringRequestParameters
            {
                SelectionProfile = VehicleSelectionProfile.Single
            });

        var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();

        return vehicleModel is not null
            ? Mapper.Map<VehicleDataModel, Vehicle>(vehicleModel)
            : null;
    }

    public async Task<IDictionary<string, decimal>> GetPriceRange(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!)
    {
        var range = new Dictionary<string, string>();

        throw new NotImplementedException();
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleSelectionProfile,
            Vehicle,
            VehicleDataModel,
            IVehicleFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleQueryBuilder(new VehicleSelectionProfiles(), new VehicleFilteringCriteria());
}