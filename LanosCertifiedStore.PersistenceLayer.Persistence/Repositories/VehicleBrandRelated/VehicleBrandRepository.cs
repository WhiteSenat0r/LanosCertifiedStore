using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleBrandRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleBrandRelated;

internal class VehicleBrandRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleBrand, VehicleBrandDataModel>(mapper, dbContext)
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
        var vehicleBrandQueryEvaluator = GetQueryEvaluator(null);

        var vehicleBrandQuery = vehicleBrandQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleBrandModel = await vehicleBrandQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleBrandModel is not null 
            ? Mapper.Map<VehicleBrandDataModel, VehicleBrand>(vehicleBrandModel) 
            : null;
    }

    public override Task<int> CountAsync(IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null)
    {
        var vehicleBrandQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
        
        var countedQueryable = vehicleBrandQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    public override async Task RemoveExistingEntity(Guid id)
    {
        var vehicleBrandQueryEvaluator = GetQueryEvaluator(null);

        var vehicleBrandQuery = vehicleBrandQueryEvaluator.GetSingleEntityQueryable(id);

        var removedEntity = await vehicleBrandQuery.AsNoTracking().SingleOrDefaultAsync();

        if (removedEntity is not null)
        {
            Context.Set<VehicleModelDataModel>().RemoveRange(removedEntity.Models);
            Context.Set<VehicleBrandDataModel>().Remove(removedEntity);
        }
    }

    private protected override IQueryable<VehicleBrandDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters)
    {
        var vehicleBrandQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        return vehicleBrandQueryEvaluator.GetAllEntitiesQueryable();
    }
    
    private protected override BaseQueryEvaluator<VehicleBrand, VehicleBrandDataModel> GetQueryEvaluator(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters) =>
        new VehicleBrandQueryEvaluator(
            includedAspects: VehicleBrandIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleBrandDataModel>(),
            vehicleFilteringCriteria: new VehicleBrandFilteringCriteria());
}