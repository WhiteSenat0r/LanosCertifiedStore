namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated;

// TODO
// internal class VehicleBodyTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleBodyTypeSelectionProfile,
//         VehicleBodyType,
//         VehicleBodyType,
//         IVehicleBodyTypeFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleBodyType>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters = null!)
//     {
//         var vehicleBodyTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleBodyTypeModels = await vehicleBodyTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleBodyType>, IReadOnlyList<VehicleBodyType>>(vehicleBodyTypeModels);
//     }
//
//     public override async Task<VehicleBodyType?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleBodyTypeModelsQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleBodyType>(), new VehicleBodyTypeFilteringRequestParameters());
//
//         var vehicleBodyTypeModel = await vehicleBodyTypeModelsQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleBodyTypeModel is not null 
//             ? Mapper.Map<VehicleBodyType, VehicleBodyType>(vehicleBodyTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleBodyType>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleBodyType> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleBodyType>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleBodyTypeSelectionProfile,
//             VehicleBodyType,
//             VehicleBodyType,
//             IVehicleBodyTypeFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleBodyTypeQueryBuilder(new VehicleBodyTypeSelectionProfiles(), new VehicleBodyTypeFilteringCriteria());
// }