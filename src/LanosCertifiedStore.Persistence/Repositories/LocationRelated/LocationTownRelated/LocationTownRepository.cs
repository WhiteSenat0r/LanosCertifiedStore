namespace Persistence.Repositories.LocationRelated.LocationTownRelated;

// TODO
// internal class LocationTownRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleLocationTownSelectionProfile,
//         VehicleLocationTown,
//         VehicleLocationTownEntity,
//         IVehicleLocationTownFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleLocationTown>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters = null!)
//     {
//         var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleLocationTownEntity>, IReadOnlyList<VehicleLocationTown>>(
//             vehicleTypeModels);
//     }
//
//     public override async Task<VehicleLocationTown?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleLocationTownEntity>(), new VehicleLocationTownFilteringRequestParameters());
//
//         var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleTypeModel is not null 
//             ? Mapper.Map<VehicleLocationTownEntity, VehicleLocationTown>(vehicleTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleLocationTownEntity>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleLocationTownEntity> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleLocationTown>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleLocationTownEntity>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleLocationTownSelectionProfile,
//             VehicleLocationTown,
//             VehicleLocationTownEntity,
//             IVehicleLocationTownFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleLocationTownQueryBuilder(
//             new VehicleLocationTownSelectionProfiles(), new VehicleLocationTownFilteringCriteria());
// }