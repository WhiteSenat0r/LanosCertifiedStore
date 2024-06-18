namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated;

// TODO
// internal class VehicleTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleTypeSelectionProfile,
//         VehicleType,
//         VehicleTypeEntity,
//         IVehicleTypeFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleType>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null!)
//     {
//         var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleTypeEntity>, IReadOnlyList<VehicleType>>(vehicleTypeModels);
//     }
//
//     public override async Task<VehicleType?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleTypeEntity>(), new VehicleTypeFilteringRequestParameters());
//
//         var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleTypeModel is not null 
//             ? Mapper.Map<VehicleTypeEntity, VehicleType>(vehicleTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleTypeEntity>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleTypeEntity> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleType>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleTypeEntity>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleTypeSelectionProfile,
//             VehicleType,
//             VehicleTypeEntity,
//             IVehicleTypeFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleTypeQueryBuilder(new VehicleTypeSelectionProfiles(), new VehicleTypeFilteringCriteria());
// }