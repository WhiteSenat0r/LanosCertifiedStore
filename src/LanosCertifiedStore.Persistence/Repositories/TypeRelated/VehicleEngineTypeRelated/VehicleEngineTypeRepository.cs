namespace Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated;

// TODO
// internal class VehicleEngineTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleEngineTypeSelectionProfile,
//         VehicleEngineType,
//         VehicleEngineTypeEntity,
//         IVehicleEngineTypeFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleEngineType>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters = null!)
//     {
//         var vehicleEngineTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleEngineTypeModels = await vehicleEngineTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleEngineTypeEntity>, IReadOnlyList<VehicleEngineType>>
//             (vehicleEngineTypeModels);
//     }
//
//     public override async Task<VehicleEngineType?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleEngineTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleEngineTypeEntity>(), new VehicleEngineTypeFilteringRequestParameters());
//
//         var vehicleEngineTypeModel = await vehicleEngineTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleEngineTypeModel is not null 
//             ? Mapper.Map<VehicleEngineTypeEntity, VehicleEngineType>(vehicleEngineTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleEngineTypeEntity>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleEngineTypeEntity> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleEngineType>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleEngineTypeEntity>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleEngineTypeSelectionProfile,
//             VehicleEngineType,
//             VehicleEngineTypeEntity,
//             IVehicleEngineTypeFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleEngineTypeQueryBuilder(
//             new VehicleEngineTypeSelectionProfiles(), new VehicleEngineTypeFilteringCriteria());
// }