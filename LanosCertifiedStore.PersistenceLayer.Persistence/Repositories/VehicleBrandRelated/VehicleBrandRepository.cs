using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleBrandRelated;

internal sealed class VehicleBrandRepository(IMapper mapper, ApplicationDatabaseContext dbContext) :
    GenericRepository<VehicleBrandSelectionProfile, VehicleBrand, VehicleBrandDataModel>(mapper, dbContext)
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
        var vehicleBrandQuery = QueryEvaluator.GetSingleEntityQueryable(
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
        var countedQueryable = QueryEvaluator.GetRelevantCountQueryable(
            Context.Set<VehicleBrandDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    public override async Task RemoveExistingEntity(Guid id)
    {
        var vehicleBrandQuery = QueryEvaluator.GetSingleEntityQueryable(
            id, Context.Set<VehicleBrandDataModel>());

        var removedEntity = await vehicleBrandQuery.AsNoTracking().SingleOrDefaultAsync();

        if (removedEntity is not null)
        {
            Context.Set<VehicleModelDataModel>().RemoveRange(removedEntity.Models);
            Context.Set<VehicleBrandDataModel>().Remove(removedEntity);
        }
    }

    private protected override IQueryable<VehicleBrandDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters) =>
        QueryEvaluator.GetAllEntitiesQueryable(
            Context.Set<VehicleBrandDataModel>(), filteringRequestParameters);

    private protected override BaseQueryEvaluator<VehicleBrandSelectionProfile, VehicleBrand, VehicleBrandDataModel>
        GetQueryEvaluator() =>
        new VehicleBrandQueryEvaluator(
            new VehicleBrandSelectionProfiles(),
            new VehicleBrandFilteringCriteria());
}