using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
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
        var vehicleModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleModels = await vehicleModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleBrandDataModel>, IReadOnlyList<VehicleBrand>>(vehicleModels);
    }

    public override async Task<VehicleBrand?> GetEntityByIdAsync(Guid id)
    {
        var vehicleBrandQueryEvaluator = GetVehicleQueryEvaluator(null);

        var vehicleModelQuery = vehicleBrandQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleBrandModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleBrandModel is not null 
            ? Mapper.Map<VehicleBrandDataModel, VehicleBrand>(vehicleBrandModel) 
            : null;
    }

    public override Task<int> CountAsync(IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null)
    {
        var vehicleBrandQueryEvaluator = GetVehicleQueryEvaluator(filteringRequestParameters);
        
        var countedQueryable = vehicleBrandQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleBrandDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters)
    {
        var vehicleBrandQueryEvaluator = GetVehicleQueryEvaluator(filteringRequestParameters);

        return vehicleBrandQueryEvaluator.GetAllEntitiesQueryable();
    }
    
    private protected override BaseQueryEvaluator<VehicleBrand, VehicleBrandDataModel> GetVehicleQueryEvaluator(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters) =>
        new VehicleBrandQueryEvaluator(
            includedAspects: VehicleBrandIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleBrandDataModel>(),
            vehicleFilteringCriteria: new VehicleBrandFilteringCriteria());
}