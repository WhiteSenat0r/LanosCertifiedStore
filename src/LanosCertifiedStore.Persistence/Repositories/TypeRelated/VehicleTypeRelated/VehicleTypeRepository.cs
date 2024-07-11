namespace Persistence.Repositories.TypeRelated.VehicleTypeRelated;

// TODO
// internal class VehicleTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleTypeSelectionProfile,
//         VehicleType,
//         VehicleType,
//         IVehicleTypeFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleType>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null!)
//     {
//         var vehicleTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleTypeModels = await vehicleTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleType>, IReadOnlyList<VehicleType>>(vehicleTypeModels);
//     }
//
//     public override async Task<VehicleType?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleType>(), new VehicleTypeFilteringRequestParameters());
//
//         var vehicleTypeModel = await vehicleTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleTypeModel is not null 
//             ? Mapper.Map<VehicleType, VehicleType>(vehicleTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleType>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleType> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleType>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleType>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleTypeSelectionProfile,
//             VehicleType,
//             VehicleType,
//             IVehicleTypeFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleTypeQueryBuilder(new VehicleTypeSelectionProfiles(), new VehicleTypeFilteringCriteria());
// }