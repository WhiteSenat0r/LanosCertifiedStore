namespace Persistence.Repositories.LocationRelated.LocationAreaRelated;

// TODO
// internal class LocationAreaRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleLocationAreaSelectionProfile,
//         VehicleLocationArea,
//         VehicleLocationArea,
//         IVehicleLocationAreaFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleLocationArea>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters = null!)
//     {
//         var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleLocationArea>, IReadOnlyList<VehicleLocationArea>>(
//             vehicleTypeModels);
//     }
//
//     public override async Task<VehicleLocationArea?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleLocationArea>(), new VehicleLocationAreaFilteringRequestParameters());
//
//         var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleTypeModel is not null 
//             ? Mapper.Map<VehicleLocationArea, VehicleLocationArea>(vehicleTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleLocationArea>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleLocationArea> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleLocationArea>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleLocationArea>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleLocationAreaSelectionProfile,
//             VehicleLocationArea,
//             VehicleLocationArea,
//             IVehicleLocationAreaFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleLocationAreaQueryBuilder(
//             new VehicleLocationAreaSelectionProfiles(), new VehicleLocationAreaFilteringCriteria());
// }