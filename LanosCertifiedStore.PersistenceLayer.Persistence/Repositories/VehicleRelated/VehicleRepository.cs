using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleRelated;

internal class VehicleRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<Vehicle, VehicleDataModel>(mapper, dbContext)
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
        var vehicleQueryEvaluator = GetVehicleQueryEvaluator(null);

        var vehicleModelQuery = vehicleQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleModel is not null 
            ? Mapper.Map<VehicleDataModel, Vehicle>(vehicleModel) 
            : null;
    }
    
    private protected override IQueryable<VehicleDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters)
    {
        var vehicleQueryEvaluator = GetVehicleQueryEvaluator(filteringRequestParameters);

        return vehicleQueryEvaluator.GetAllEntitiesQueryable();
    }
    
    private VehicleQueryEvaluator GetVehicleQueryEvaluator(
        IFilteringRequestParameters<Vehicle>? filteringRequestParameters) =>
        new(
            includedAspects: VehicleIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleDataModel>(),
            vehicleFilteringCriteria: new VehicleFilteringCriteria());
}