using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated;
using Persistence.Repositories.VehicleBrandRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleBrandRelated;

internal sealed class VehicleBrandRepository(IMapper mapper, ApplicationDatabaseContext dbContext) :
    GenericRepository<VehicleBrandSelectionProfile,
        VehicleBrand,
        VehicleBrandDataModel,
        IVehicleBrandFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleBrand>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null!)
    {
        var vehicleBrandsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleBrands = await vehicleBrandsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleBrandDataModel>, IReadOnlyList<VehicleBrand>>(vehicleBrands);
    }

    public override async Task<VehicleBrand?> GetEntityByIdAsync(Guid id)
    {
        var vehicleBrandQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleBrandDataModel>(), new VehicleBrandFilteringRequestParameters
        {
            SelectionProfile = VehicleBrandSelectionProfile.Single
        });

        var vehicleBrandModel = await vehicleBrandQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleBrandModel is not null 
            ? Mapper.Map<VehicleBrandDataModel, VehicleBrand>(vehicleBrandModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleBrandDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleBrandDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleBrandDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleBrandSelectionProfile,
        VehicleBrand,
        VehicleBrandDataModel, 
        IVehicleBrandFilteringRequestParameters> GetQueryBuilder() =>
        new VehicleBrandQueryBuilder(
            new VehicleBrandSelectionProfiles(),
            new VehicleBrandFilteringCriteria());
}