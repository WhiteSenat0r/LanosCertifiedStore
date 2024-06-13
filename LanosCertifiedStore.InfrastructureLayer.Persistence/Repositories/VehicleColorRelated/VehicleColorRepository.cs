using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated;
using Persistence.Repositories.VehicleColorRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleColorRelated;

internal class VehicleColorRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleColorSelectionProfile,
        VehicleColor,
        VehicleColorDataModel,
        IVehicleColorFilteringRequestParameters>(mapper, dbContext)
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
        var vehicleColorQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleColorDataModel>(), new VehicleColorFilteringRequestParameters());

        var vehicleColorModel = await vehicleColorQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleColorModel is not null 
            ? Mapper.Map<VehicleColorDataModel, VehicleColor>(vehicleColorModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleColorDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleColorDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleColorDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleColorSelectionProfile,
            VehicleColor,
            VehicleColorDataModel,
            IVehicleColorFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleColorQueryBuilder(
            new VehicleColorSelectionProfiles(),
            new VehicleColorFilteringCriteria());
}