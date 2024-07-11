namespace Persistence.Repositories.LocationRelated.LocationRegionRelated;

// TODO
// internal class LocationRegionRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleLocationRegionSelectionProfile,
//         VehicleLocationRegion,
//         VehicleLocationRegion,
//         IVehicleLocationRegionFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleLocationRegion>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters = null!)
//     {
//         var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleLocationRegion>, IReadOnlyList<VehicleLocationRegion>>(
//             vehicleTypeModels);
//     }
//
//     public override async Task<VehicleLocationRegion?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleLocationRegion>(), new VehicleLocationRegionFilteringRequestParameters());
//
//         var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleTypeModel is not null 
//             ? Mapper.Map<VehicleLocationRegion, VehicleLocationRegion>(vehicleTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleLocationRegion>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleLocationRegion> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleLocationRegion>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleLocationRegion>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleLocationRegionSelectionProfile,
//             VehicleLocationRegion,
//             VehicleLocationRegion,
//             IVehicleLocationRegionFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleLocationRegionQueryBuilder(
//             new VehicleLocationRegionSelectionProfiles(), new VehicleLocationRegionFilteringCriteria());
// }