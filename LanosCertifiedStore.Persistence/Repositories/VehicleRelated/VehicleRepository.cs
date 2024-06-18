namespace Persistence.Repositories.VehicleRelated;

// TODO
// internal class VehicleRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleSelectionProfile,
//         Vehicle,
//         VehicleEntity, 
//         IVehicleFilteringRequestParameters>(mapper, dbContext),
//         IVehicleRepositoryExtensions
// {
//     public override async Task<IReadOnlyList<Vehicle>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!)
//     {
//         var vehicleModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleModels = await vehicleModelsQuery.AsNoTracking().ToListAsync();
//
//         return Mapper.Map<IReadOnlyList<VehicleEntity>, IReadOnlyList<Vehicle>>(vehicleModels);
//     }
//
//     public override async Task<Vehicle?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleEntity>(), new VehicleFilteringRequestParameters
//             {
//                 SelectionProfile = VehicleSelectionProfile.Single
//             });
//
//         var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();
//
//         return vehicleModel is not null
//             ? Mapper.Map<VehicleEntity, Vehicle>(vehicleModel)
//             : null;
//     }
//
//     public Task<IDictionary<string, decimal>> GetPriceRange(
//         IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!) =>
//         (QueryBuilder as VehicleQueryBuilder)!.GetPriceRange(
//             Context.Set<VehicleEntity>(), filteringRequestParameters);
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleEntity>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleEntity> GetRelevantQueryable(
//         IFilteringRequestParameters<Vehicle>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleEntity>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleSelectionProfile,
//             Vehicle,
//             VehicleEntity,
//             IVehicleFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleQueryBuilder(new VehicleSelectionProfiles(), new VehicleFilteringCriteria());
// }