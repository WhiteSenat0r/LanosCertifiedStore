namespace Persistence.Repositories.VehicleRelated;

// TODO
// internal class VehicleRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleSelectionProfile,
//         Vehicle,
//         Vehicle, 
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
//         return Mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<Vehicle>>(vehicleModels);
//     }
//
//     public override async Task<Vehicle?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<Vehicle>(), new VehicleFilteringRequestParameters
//             {
//                 ProjectionProfile = VehicleSelectionProfile.Single
//             });
//
//         var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();
//
//         return vehicleModel is not null
//             ? Mapper.Map<Vehicle, Vehicle>(vehicleModel)
//             : null;
//     }
//
//     public Task<IDictionary<string, decimal>> GetPriceRange(
//         IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null!) =>
//         (QueryBuilder as VehicleQueryBuilder)!.GetPriceRange(
//             Context.Set<Vehicle>(), filteringRequestParameters);
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<Vehicle>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<Vehicle>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<Vehicle> GetRelevantQueryable(
//         IFilteringRequestParameters<Vehicle>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<Vehicle>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleSelectionProfile,
//             Vehicle,
//             Vehicle,
//             IVehicleFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleQueryBuilder(new VehicleSelectionProfiles(), new VehicleFilteringCriteria());
// }